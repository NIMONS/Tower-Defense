using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : TDMonoBehaviour
{
    [Header("Refernes")]
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected SpriteRenderer _spriteRenderer;

    [Header("Attributes")]
    [SerializeField] protected float moveSpeed = 2f;

    protected Transform target;
    protected int pathIndex = 0;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadRigidbody2D();
        this.LoadAnimator();
        this.LoadSpriteRenderer();
    }

    protected void LoadSpriteRenderer()
    {
        if (this._spriteRenderer != null) return;
        this._spriteRenderer = transform.GetComponent<SpriteRenderer>();
        //Debug.LogWarning(transform.name + ": LoadSpriteRenderer", gameObject);
    }

    protected void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator", gameObject);
    }

    protected void LoadRigidbody2D()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigidbody2D", gameObject);
    }

    protected void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl=transform.parent.parent.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected override void Start()
    {
        base.Start();
        this.ProcessMove();
    }

    protected override void Update()
    {
        base.Update();
        this.MoveFollowTarget();
    }

    protected void FixedUpdate()
    {
        this.HandleDirection();
    }

    protected void ProcessMove()
    {
        this.target = LevelManager.Instance.Paths[pathIndex];
    }

    protected void MoveFollowTarget()
    {
        float dis = Vector2.Distance(transform.parent.position, target.position);
        int lengthPath = LevelManager.Instance.Paths.Count;
        if (dis <= 0.1f)
        {
            pathIndex++;
            if (pathIndex == lengthPath)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                this.target = LevelManager.Instance.Paths[pathIndex];
                if (target.position.x>transform.parent.position.x) 
                {
                    _spriteRenderer.flipX = false;
                }
                else
                {
                    _spriteRenderer.flipX=true;
                }
            }
        }
    }

    protected void HandleDirection()
    {
        this.animator.SetBool("isRunning", true);
        transform.parent.position = Vector2.MoveTowards(transform.parent.position, target.position, this.moveSpeed * Time.fixedDeltaTime);
    }

    public void SetMoveSpeed(float speed)
    {
        this.moveSpeed = speed;
    }
}
