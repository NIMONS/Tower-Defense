using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : TDMonoBehaviour
{
    [SerializeField] protected Bullet bullet;
    public Bullet Bullet=>bullet;
    [SerializeField] protected TankCtrl tankCtrl;
    public TankCtrl TankCtrl => tankCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBullet();
        this.LoadTankCtrl();
    }

    protected void LoadTankCtrl()
    {
        if (this.tankCtrl != null) return;
        this.tankCtrl = GameObject.FindObjectOfType<TankCtrl>();
        Debug.LogWarning(transform.name + ": LoadTankCtrl", gameObject);
    }

    protected void LoadBullet()
    {
        if (this.bullet != null) return;
        this.bullet = transform.GetComponentInChildren<Bullet>();
        Debug.LogWarning(transform.name + ": LoadBullet", gameObject);
    }
}
