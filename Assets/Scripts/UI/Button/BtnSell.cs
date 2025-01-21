using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSell : TDMonoBehaviour
{
    [SerializeField] protected Transform Notification;
    [SerializeField] protected UpdateAndSellCtrl updateAndSellCtrl;
    private GameObject tower;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNotification();
        this.LoadUpdateAndSellCtrl();

	}

    protected void LoadUpdateAndSellCtrl()
    {
        if (this.updateAndSellCtrl != null) return;
        this.updateAndSellCtrl = transform.parent.parent.parent.parent.Find("UpdateAndSellPanel").GetComponent<UpdateAndSellCtrl>();
        Debug.LogWarning(transform.name + ": LoadUpdateAndSellCtrl", gameObject);
    }

	protected void LoadNotification()
	{
		if (this.Notification != null) return;
		this.Notification = transform.parent.parent.parent.Find("Notification").GetComponent<Transform>();
		Debug.LogWarning(transform.name + ": LoadNotification", gameObject);
	}

	public void SellTurretTurret()
    {
        //this.Notification.gameObject.SetActive(true);
        this.GetInfoTower();
    }

    protected void GetInfoTower()
    {
        this.tower = this.updateAndSellCtrl.Tower;
		Debug.Log("infor tower: " + tower);

	}
}
