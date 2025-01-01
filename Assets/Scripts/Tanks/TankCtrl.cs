using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCtrl : TDMonoBehaviour
{
    [SerializeField] protected Tank tank;
    public Tank Tank => tank;
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl => bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTank();
        this.LoadBulletCtrl();
    }

    protected void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = GameObject.FindObjectOfType<BulletCtrl>();
        Debug.LogWarning(transform.name + ": LoadBulletCtrl", gameObject);
    }

    protected void LoadTank()
    {
        if (this.tank != null) return;
        this.tank = transform.GetComponent<Tank>();
        Debug.LogWarning(transform.name + ": LoadTank", gameObject);
    }

}
