using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PriceSell : TDMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI text;
	[SerializeField] protected UpdateAndSellCtrl updateAndSellCtrl;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadTextMeshPro();
		this.LoadUpdateAndSellCtrl();
	}
	protected void LoadUpdateAndSellCtrl()
	{
		if (this.updateAndSellCtrl != null) return;
		this.updateAndSellCtrl = transform.parent.parent.parent.GetComponent<UpdateAndSellCtrl>();
		Debug.Log(transform.name + ": LoadUpdateAndSellCtrl", gameObject);
	}

	protected void LoadTextMeshPro()
	{
		if (this.text != null) return;
		this.text = transform.GetComponentInChildren<TextMeshProUGUI>();
		Debug.Log(transform.name + ": LoadTextMeshPro", gameObject);
	}

	protected override void Update()
	{
		base.Update();
		this.text.text = this.updateAndSellCtrl.TowerObj.costSell.ToString();
	}
}
