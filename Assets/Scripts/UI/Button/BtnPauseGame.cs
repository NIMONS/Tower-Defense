using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPauseGame : BtnCloseShopPanel
{
    protected override void Start()
    {
        base.Start();
        this.windowShop.gameObject.SetActive(false);
    }

    public override void CloseShopPanel()
    {
        base.CloseShopPanel();
        Application.Quit();
    }
}
