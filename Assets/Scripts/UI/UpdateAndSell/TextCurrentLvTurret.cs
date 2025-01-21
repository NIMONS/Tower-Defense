using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCurrentLvTurret : TDMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textMeshProUGUI;
    [SerializeField] protected UpdateAndSellCtrl updateAndSellCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMeshProUGUI();
        this.LoadUpdateAndSellCtrl();

	}
	protected void LoadUpdateAndSellCtrl()
	{
		if (this.updateAndSellCtrl != null) return;
		this.updateAndSellCtrl = transform.parent.parent.GetComponent<UpdateAndSellCtrl>();
		Debug.LogWarning(transform.name + ": LoadUpdateAndSellCtrl", gameObject);
	}

	protected void LoadTextMeshProUGUI()
    {
        if (this.textMeshProUGUI != null) return;
        this.textMeshProUGUI=transform.GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadTextMeshProUGUI", gameObject);
    }

	protected override void Update()
	{
		base.Update();
		this.textMeshProUGUI.text = this.updateAndSellCtrl.TowerObj.level.ToString();
	}
}
