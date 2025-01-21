using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAndSellCtrl : TDMonoBehaviour
{
    [Header("References")]
    [SerializeField] protected UICtrl uICtrl;
    public UICtrl UICtrl => uICtrl;
    [SerializeField] protected BtnUpgrade btnUpgrade;
    [SerializeField] protected BtnSell btnSell;
    [SerializeField] protected TextCurrentLvTurret textCurrentLvTurret;
    [SerializeField] protected GameObject tower;
    public GameObject Tower => tower;
    [SerializeField] protected Tower towerObj;
	public Tower TowerObj => towerObj;


	protected override void Start()
    {
        base.Start();
        transform.gameObject.SetActive(false);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnUpgrade();
        this.LoadBtnSell();
        this.LoadTextCurrentLvTurret();
        this.LoadUICtrl();
	}
	protected void LoadUICtrl()
	{
		if (this.uICtrl != null) return;
		this.uICtrl = transform.parent.GetComponent<UICtrl>();
		Debug.LogWarning(transform.name + ": LoadUICtrl", gameObject);
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

    protected void LoadBtnUpgrade()
    {
        if(btnUpgrade != null) return;
        this.btnUpgrade=transform.Find("UpdateAndSell-Image").Find("Upgrade").GetComponentInChildren<BtnUpgrade>();
        Debug.LogWarning(transform.name + ": LoadBtnUpgrade", gameObject);
    }

    public void SetTower(Tower towerObj, GameObject tower)
    {
        this.tower = tower;
        this.towerObj = towerObj;
    }
}
