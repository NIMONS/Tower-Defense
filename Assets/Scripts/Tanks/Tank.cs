using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tank : TDMonoBehaviour
{
    [Header("References")]
    [SerializeField] protected Transform tankRotationPoint;
    public Transform TankRotationPoint=> tankRotationPoint;
    [SerializeField] protected LayerMask enemyMask;
    [SerializeField] protected Transform bulletPrefab;
    [SerializeField] protected Transform firingPoint;
    [SerializeField] protected TankCtrl tankCtrl;
    [SerializeField] protected DestroyByDistance destroyBullet;
    [SerializeField] protected Transform holder;


    [Header("Attributes")]
    [SerializeField] protected float targetingRange = 3f;
    [SerializeField] protected float rotationSpeed = 200f;
    [SerializeField] protected float bps = 1f;//Bullets per second


    private Transform target;
    public Transform Target=>target;
    private float timeUnitilFire;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTankRotationPoint();
        this.LoadTankCtrl();
        this.LoadFiringPoint();
        this.LoadBulletPrefab();
        this.LoadHolader();
        this.LoadDestroyByDistance();
    }

    protected void LoadDestroyByDistance()
    {
        if (this.destroyBullet != null) return;
        this.destroyBullet = transform.GetComponentInChildren<DestroyByDistance>();
        Debug.LogWarning(transform.name + ": LoadDestroyByDistance", gameObject);
    }

    protected void LoadHolader()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder").GetComponent<Transform>();
        Debug.LogWarning(transform.name + ": LoadHolader", gameObject);
    }

    protected void LoadBulletPrefab()
    {
        if (this.bulletPrefab != null) return;
        this.bulletPrefab = transform.Find("Bullets").Find("Model").GetComponent<Transform>();
        Debug.LogWarning(transform.name + ": LoadBulletPrefab", gameObject);
    }

    protected void LoadFiringPoint()
    {
        if (this.firingPoint != null) return;
        this.firingPoint = transform.Find("RotatePoint").Find("FiringPoint").GetComponent<Transform>();
        Debug.LogWarning(transform.name + ": LoadFiringPoint", gameObject);
    }

    protected void LoadTankCtrl()
    {
        if (this.tankCtrl != null) return;
        this.tankCtrl = transform.GetComponent<TankCtrl>();
        Debug.LogWarning(transform.name + ": LoadTankCtrl", gameObject);
    }

    protected void LoadTankRotationPoint()
    {
        if (this.tankRotationPoint != null) return;
        this.tankRotationPoint=transform.Find("RotatePoint").GetComponent<Transform>();
        Debug.LogWarning(transform.name + ": LoadTankRotationPoint", gameObject);
    }

    protected override void Update()
    {
        base.Update();
        this.DetectEnemiesInSight();
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, targetingRange);
    }

    protected void DetectEnemiesInSight()
    {
        if (this.target == null)
        {
            this.FindTarget();
            return;
        }

        this.RotateTowardsTarget();
        if (!this.CheckTarrgetIsInRange())
        {
            this.target = null;
        }
        else
        {
            this.timeUnitilFire += Time.deltaTime;

            if (timeUnitilFire >= 1f / bps)
            {
                this.Shoot();
                this.timeUnitilFire = 0f;
            }
        }
    }

    protected void Shoot()
    {
        Transform bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        bulletObj.gameObject.SetActive(true);
        Bullet bulletScript= bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(this.target);
        bulletObj.SetParent(this.holder);
        var bullets = this.destroyBullet.Bullets;
        foreach(Transform i in this.holder)
        {
            bullets.Add(i);
        }
    }

    public Transform FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange,(Vector2)transform.position,0f, enemyMask);

        if(hits.Length> 0)
        {
            return target = hits[0].transform;
        }
        return null;
    }

    protected void RotateTowardsTarget()
    {
        float angle=Mathf.Atan2(target.position.y-transform.position.y,target.position.x-transform.position.x)*Mathf.Rad2Deg-90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        tankRotationPoint.rotation = Quaternion.RotateTowards(tankRotationPoint.rotation,targetRotation,rotationSpeed*Time.deltaTime);
    }

    protected bool CheckTarrgetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }
}
