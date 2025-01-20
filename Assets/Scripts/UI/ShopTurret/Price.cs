using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Price : BaseLoadTextM
{
    protected override void LoadTextMeshPro()
    {
        base.LoadTextMeshPro();
        if (this.textMeshPro != null) return;
        this.textMeshPro=transform.Find("CurrentCoin").GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadTextMeshPro", gameObject);
    }

    protected override void OnGUI()
    {
        base.OnGUI();
        this.textMeshPro.text = LevelManager.Instance.currency.ToString();
    }
}
