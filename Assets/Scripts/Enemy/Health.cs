using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : TDMonoBehaviour
{
    [Header("References")]
    [SerializeField] protected EnemyMovement enemyMovement;
    [SerializeField] protected UICtrl uICtrl;

    [Header("Attributes")]
    [SerializeField] protected int currentHealth = 0;
    [SerializeField] protected int maxHealth = 10;
    [SerializeField] protected int currencyWorth = 50;//số tiền nhận đc khi tiêu diệt enemy
    [SerializeField] protected int damageCaused = 1;//sát thương của enemy có thể gây ra 
    

    private bool isDestroyed = false;
    private float recoveryDelay = 0.5f;//thời gian chờ trước khi quái tiếp tục di chuyển sau khi nhận sát thương

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyMovement();
        this.LoadUICtrl();
    }

    protected void LoadUICtrl()
    {
        if (this.uICtrl != null) return;
        this.uICtrl = GameObject.FindObjectOfType<UICtrl>();
        Debug.LogWarning(transform.name + ": LoadUICtrl", gameObject);
    }

    protected void LoadEnemyMovement()
    {
        if (this.enemyMovement != null) return;
        this.enemyMovement=transform.GetComponent<EnemyMovement>();
        Debug.LogWarning(transform.name + ": LoadEnemyMovement", gameObject);
    }

    protected override void Start()
    {
        base.Start();
        this.BuffHp();
    }

    protected override void Update()
    {
        base.Update();
        this.causeDamage();
    }

    protected void BuffHp()
    {
        this.currentHealth=this.maxHealth;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        this.enemyMovement.Animator.SetBool("isHit", true);
        if (currentHealth <= 0&&!isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.Instance.IncreaseCurrency(currencyWorth);
            this.isDestroyed = true;
            Destroy(gameObject);
        }
        StartCoroutine(TakeDamageCoolDown());
    }

    IEnumerator TakeDamageCoolDown()
    {
        this.enemyMovement.SetMoveSpeed(0);
        yield return new WaitForSeconds(this.recoveryDelay);
        this.enemyMovement.Animator.SetBool("isHit", false);
        this.enemyMovement.SetMoveSpeed(2);
    }

    public bool getStatusEnemies()
    {
        return isDestroyed;
    }

    protected void causeDamage()
    {
        Transform endPoint = LevelManager.Instance.EndPoint;
        float disBetweenTwoPoints=Vector2.Distance(transform.parent.position, endPoint.position);

        if (disBetweenTwoPoints < 1f)
        {
            this.uICtrl.PlayerUI.minusHP(damageCaused);
            Debug.Log("Trừ máu player");
        }
    }
}
