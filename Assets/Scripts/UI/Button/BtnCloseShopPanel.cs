using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseShopPanel : TDMonoBehaviour
{
    [SerializeField] protected Transform windowShop;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWindowShop();
    }

    protected void LoadWindowShop()
    {
        if (this.windowShop != null) return;
        this.windowShop=transform.parent.parent.GetComponent<Transform>();
        Debug.LogWarning(transform.name + ": LoadWindowShop", gameObject);
    }

    public virtual void CloseShopPanel()
    {
        //Debug.Log("Close Shop");
        this.windowShop.gameObject.SetActive(false);
        //this.windowShop.se
    }
}
