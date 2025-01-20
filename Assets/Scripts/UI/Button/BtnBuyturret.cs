using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBuyturret : TDMonoBehaviour
{
    [SerializeField] protected WindowShopCtrl windowShopCtrl;
    [SerializeField] protected Transform Notification;
    private GameObject tower;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWindowShopCtrl();
        this.LoadNotification();
    }

    protected void LoadNotification()
    {
        if (this.Notification != null) return;
        this.Notification = transform.parent.parent.Find("Notification").GetComponent<Transform>();
        this.Notification.gameObject.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadNotification", gameObject);
    }

    protected void LoadWindowShopCtrl()
    {
        if (this.windowShopCtrl != null) return;
        this.windowShopCtrl=transform.parent.parent.GetComponent<WindowShopCtrl>();
        Debug.LogWarning(transform.name + ": LoadWindowShopCtrl", gameObject);
    }

    public void SetTurret(GameObject turet)
    {
        this.tower= turet;
    }

    public GameObject GetTower()
    {
        return this.tower;
    }

    public void BuyTurret()
    {
        if (tower != null) return;
        Tower towerToBuild = BuildManager.Instance.getSelectedTower();

        int currency = LevelManager.Instance.currency;

        if (towerToBuild.cost > currency)
        {
            this.Notification.gameObject.SetActive(true);
            return;
        }

        LevelManager.Instance.SpendCurrency(towerToBuild.cost);

        //vị trí đặt pháo
        Transform newPosTurret = this.windowShopCtrl.GetPosTurret();


        if (newPosTurret != null)
        {
            //Debug.Log(towerToBuild.turretPrefab);
            
            if (this.tower == null)
            {
                this.tower = Instantiate(towerToBuild.turretPrefab, newPosTurret.position, Quaternion.identity);
                newPosTurret.GetComponent<Plot>().SetTower(this.tower);
				this.tower.transform.SetParent(this.windowShopCtrl.LevelManager.HolderTank);
			}
			this.tower = null;
        }
        
        if (windowShopCtrl != null)
        {
            this.windowShopCtrl.SetPosTurret(this.windowShopCtrl.PosTurret);
            this.windowShopCtrl.gameObject.SetActive(false);
        }

    }
}
