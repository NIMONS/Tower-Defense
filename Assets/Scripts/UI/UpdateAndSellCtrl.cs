using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAndSellCtrl : TDMonoBehaviour
{
    [Header("References")]
    [SerializeField] protected BtnCloseShopPanel btnCloseShopPanel;
    [SerializeField] protected BtnUpgrade btnUpgrade;
    [SerializeField] protected BtnSell btnSell;
    [SerializeField] protected TextCurrentLvTurret textCurrentLvTurret;

    protected override void Start()
    {
        base.Start();
        transform.gameObject.SetActive(false);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnCloseShopPanel();
        this.LoadBtnUpgrade();
        this.LoadBtnSell();
        this.LoadTextCurrentLvTurret();
    }

    protected void LoadTextCurrentLvTurret()
    {
        if (this.textCurrentLvTurret != null) return;
        this.textCurrentLvTurret = transform.Find("UpdateAndSell-Image").GetComponentInChildren<TextCurrentLvTurret>();
        Debug.LogWarning(transform.name + ": LoadTextCurrentLvTurret", gameObject);
    }

    protected void LoadBtnSell()
    {
        if (this.btnSell != null) return;
        this.btnSell=transform.Find("UpdateAndSell-Image").Find("Sell").GetComponentInChildren<BtnSell>();
        Debug.LogWarning(transform.name + ": LoadBtnSell", gameObject);
    }

    protected void LoadBtnCloseShopPanel()
    {
        if (btnCloseShopPanel != null) return;
        this.btnCloseShopPanel=transform.Find("UpdateAndSell-Image").GetComponentInChildren<BtnCloseShopPanel>();
        Debug.LogWarning(transform.name + ": LoadBtnCloseShopPanel", gameObject);
    }

    protected void LoadBtnUpgrade()
    {
        if(btnUpgrade != null) return;
        this.btnUpgrade=transform.Find("UpdateAndSell-Image").Find("Upgrade").GetComponentInChildren<BtnUpgrade>();
        Debug.LogWarning(transform.name + ": LoadBtnUpgrade", gameObject);
    }
}
