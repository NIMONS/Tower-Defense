using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : TDMonoBehaviour
{
    [Header("References")]
    [SerializeField] protected WindowShopCtrl windowShopCtrl;
    public WindowShopCtrl WindowShopCtrl => windowShopCtrl;
    [SerializeField] protected Price price;
    [SerializeField] protected Wave wave;
    [SerializeField] protected Enemies enemies;
    [SerializeField] protected UpdateAndSellCtrl updateAndSellCtrl;
    [SerializeField] protected PlayerUI playerUI;
    public PlayerUI PlayerUI => playerUI;
    public UpdateAndSellCtrl UpdateAndSellCtrl => updateAndSellCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWindowShopCtrl();
        this.LoadPrice();
        this.LoadWave();
        this.LoadEnemies();
        this.LoadUpdateAndSellCtrl();
        this.LoadPlayerUI();
    }

    protected void LoadPlayerUI()
    {
        if (this.playerUI != null) return;
        this.playerUI = transform.GetComponentInChildren<PlayerUI>();
        Debug.LogWarning(transform.name + ": LoadPlayerUI", gameObject);
    }

    protected void LoadUpdateAndSellCtrl()
    {
        if (this.updateAndSellCtrl != null) return;
        this.updateAndSellCtrl = transform.GetComponentInChildren<UpdateAndSellCtrl>();
        Debug.LogWarning(transform.name + ": LoadUpdateAndSellCtrl", gameObject);
    }

    protected void LoadEnemies()
    {
        if (this.enemies != null) return;
        this.enemies = transform.Find("EnemiesAlivePanel").GetComponentInChildren<Enemies>();
        Debug.LogWarning(transform.name + ": LoadEnemies", gameObject);
    }

    protected void LoadWave()
    {
        if (this.wave != null) return;
        this.wave = transform.Find("WavePanel").GetComponentInChildren<Wave>();
        Debug.LogWarning(transform.name + ": LoadWave", gameObject);
    }

    protected void LoadPrice()
    {
        if (this.price != null) return;
        this.price = transform.Find("CoinPanel").GetComponentInChildren<Price>();
        Debug.LogWarning(transform.name + ": LoadPrice", gameObject);
    }

    protected void LoadWindowShopCtrl()
    {
        if (this.windowShopCtrl != null) return;
        this.windowShopCtrl=transform.GetComponentInChildren<WindowShopCtrl>();
        Debug.LogWarning(transform.name + ": LoadWindowShopCtrl", gameObject);
    }

}
