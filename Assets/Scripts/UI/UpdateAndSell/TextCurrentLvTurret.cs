using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCurrentLvTurret : TDMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textMeshProUGUI;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMeshProUGUI();
    }

    protected void LoadTextMeshProUGUI()
    {
        if (this.textMeshProUGUI != null) return;
        this.textMeshProUGUI=transform.GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadTextMeshProUGUI", gameObject);
    }
}
