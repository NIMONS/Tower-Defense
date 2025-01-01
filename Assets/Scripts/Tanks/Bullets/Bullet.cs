using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (CapsuleCollider2D))]
public class Bullet : TDMonoBehaviour
{
    [Header("References")]
    [SerializeField] protected CapsuleCollider2D cs;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected BulletCtrl bulletCtrl;

    [Header("Attributes")]
    [SerializeField] protected float bulletSpeed = 200f;
    [SerializeField] protected int bulletDamage = 1;

    private Transform target;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
        this.LoadRigidbody2D();
        this.LoadCapsuleCollider2D();
    }

    protected void LoadCapsuleCollider2D()
    {
        if (this.cs != null) return;
        this.cs = transform.GetComponent<CapsuleCollider2D>();
        Vector2 newSize = new Vector2(0.2027869f, 0.676899f);
        this.cs.size = newSize;
        Debug.LogWarning(transform.name + ": LoadCapsuleCollider2D", gameObject);
    }

    protected void LoadRigidbody2D()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": LoadRigidbody2D", gameObject);
    }

    protected void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.LogWarning(transform.name + ": LoadBulletCtrl", gameObject);
    }

    protected override void Update()
    {
        base.Update();

    }

    private void FixedUpdate()
    {
        this.SetDirection();
    }

    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }

    protected void SetDirection()
    {
        if (!target) return;

        Vector2 currentPos=transform.position;
        Vector2 targetPos = target.position;


        Transform gunMuzzle = this.bulletCtrl.TankCtrl.Tank.TankRotationPoint;
        Vector2 muzzlePos = gunMuzzle.position;
        Vector2 direction = (targetPos - muzzlePos).normalized;
        float angle=Mathf.Atan2(direction.y, direction.x) *Mathf.Rad2Deg-90;
        rb.rotation = angle;


        //transform.position=Vector2.MoveTowards(currentPos, targetPos, bulletSpeed*Time.fixedDeltaTime);
        rb.velocity=direction*(bulletSpeed*Time.fixedDeltaTime);
        //this.DestroyBulletByDistance();
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.GetComponent<Health>().TakeDamage(this.bulletDamage);
        Destroy(gameObject);
    }
}
