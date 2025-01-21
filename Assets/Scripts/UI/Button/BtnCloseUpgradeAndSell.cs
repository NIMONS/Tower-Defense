using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseUpgradeAndSell : BtnCloseShopPanel
{
	[SerializeField] protected UpdateAndSellCtrl windowUpgradeAndSell;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadWindowUpgradeAndSell();
	}

	protected void LoadWindowUpgradeAndSell()
	{
		if (this.windowUpgradeAndSell != null) return;
		this.windowUpgradeAndSell = transform.parent.parent.GetComponent<UpdateAndSellCtrl>();
		Debug.LogWarning(transform.name + ": LoadWindowShop", gameObject);
	}

	public override void CloseShopPanel()
	{
		base.CloseShopPanel();
		//Debug.Log("Close Shop");
		this.windowUpgradeAndSell.SetTower(null);
		//this.windowUpgradeAndSell.transform.gameObject.SetActive(false);
	}

}
