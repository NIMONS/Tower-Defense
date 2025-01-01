using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Price : BaseLoadTextM
{
    protected override void LoadTextMeshPro()
    {
        base.LoadTextMeshPro();
        this.textMeshPro=transform.Find("CurrentCoin").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadTextMeshPro", gameObject);
    }

    protected override void OnGUI()
    {
        base.OnGUI();
        this.textMeshPro.text = LevelManager.Instance.currency.ToString();
    }
}
