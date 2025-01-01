using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BaseLoadTextM : TDMonoBehaviour
{
    [Header("References")]
    [SerializeField] protected TextMeshProUGUI textMeshPro;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMeshPro();
    }

    protected virtual void LoadTextMeshPro()
    {
        //for override   
    }

    protected virtual void OnGUI()
    {
        //for override
    }
}
