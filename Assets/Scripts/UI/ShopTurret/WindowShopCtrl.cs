using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowShopCtrl : TDMonoBehaviour
{
    [SerializeField] protected BtnBuyturret btnBuyturret;
    public BtnBuyturret BtnBuyturret=>btnBuyturret;
    [SerializeField] protected UICtrl uICtrl;
    public UICtrl UICtrl=> uICtrl;
    [SerializeField] protected List<Transform> savedLocation;
    public List<Transform> SavedLocation => savedLocation;

    private Transform posTurret;
    public Transform PosTurret => posTurret;
    public void SetPosTurret(Transform posTurret)
    {
        this.posTurret = posTurret;
    }

    public Transform GetPosTurret()
    {
        return this.posTurret;
    }

    protected override void Start()
    {
        base.Start();
        transform.gameObject.SetActive(false);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnBuyTurrret();
        this.LoadUICtrl();
    }

    protected void LoadUICtrl()
    {
        if (this.uICtrl != null) return;
        this.uICtrl = transform.parent.GetComponent<UICtrl>();
        Debug.LogWarning(transform.name + ": LoadUICtrl", gameObject);
    }

    protected void LoadBtnBuyTurrret()
    {
        if (this.btnBuyturret != null) return;
        this.btnBuyturret=transform.Find("Panel").GetComponentInChildren<BtnBuyturret>();
        Debug.LogWarning(transform.name + ": LoadBtnBuyTurrret", gameObject);
    }
}
