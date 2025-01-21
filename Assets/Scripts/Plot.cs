using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : TDMonoBehaviour
{
    [Header("References")]
    [SerializeField] protected SpriteRenderer sr;
    [SerializeField] protected Color hoverColor;
    [SerializeField] protected Transform hoderTank;
    [SerializeField] protected UICtrl uICtrl;
    [SerializeField] protected WindowShopCtrl windowShopCtrl;
    [SerializeField] protected LevelManager levelManager;
    private Color startColor;
    private GameObject tower;
	private Tower towerObj;


	protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolderTank();
        this.LoadWindowShopCtrl();
        this.LoadUICtrl();
        this.LoadLevelManager();
	}
	protected void LoadLevelManager()
	{
		if (this.levelManager != null) return;
		this.levelManager = GameObject.FindObjectOfType<LevelManager>();
		Debug.LogWarning(transform.name + ": LoadLevelManager", gameObject);
	}

	protected void LoadWindowShopCtrl()
    {
        if (this.windowShopCtrl != null) return;
        this.windowShopCtrl = GameObject.FindObjectOfType<WindowShopCtrl>();
        Debug.LogWarning(transform.name + ": LoadUICtrl", gameObject);
    }

    protected void LoadUICtrl()
    {
        if (this.uICtrl != null) return;
        this.uICtrl = GameObject.FindObjectOfType<UICtrl>();
        Debug.LogWarning(transform.name + ": LoadUICtrl", gameObject);
    }

    protected void LoadHolderTank()
    {
        if (this.hoderTank != null) return;
        this.hoderTank=GameObject.Find("HolderTank").GetComponent<Transform>();
        Debug.LogWarning(transform.name+ ": LoadHolderTank",gameObject);
    }

    protected override void Start()
    {
        base.Start();
        this.startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }
    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (this.tower != null)
        {
            this.uICtrl.UpdateAndSellCtrl.gameObject.SetActive(true);
            this.uICtrl.UpdateAndSellCtrl.SetTower(this.towerObj, this.tower);
        }


        if (this.tower == null)
        {
            this.windowShopCtrl.SetPosTurret(transform);
            this.windowShopCtrl.transform.gameObject.SetActive(true);
            this.windowShopCtrl.BtnBuyturret.SetTurret(this.GetTower());
        }
    }

    public void SetTower(GameObject _tower, Tower tower)
    {
        this.tower = _tower;
        this.towerObj = tower;
    }

    public GameObject GetTower()
    {
        return this.tower;
    }
}
