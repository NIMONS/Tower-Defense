using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : TDMonoBehaviour
{
    [SerializeField] protected Transform startPoint;
    public Transform StartPoint => startPoint;
    [SerializeField] protected Transform endPoint;
    public Transform EndPoint => endPoint;
    [SerializeField] protected List<Transform> paths;
    public List<Transform> Paths => paths;
    private static LevelManager instance;
    public static LevelManager Instance=>instance;

    public int currency;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.Log("Just only 1 LevelManager allow exists");
        instance = this;
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStartPoint();
        this.LoadEndPoint();
    }

    protected void LoadEndPoint()
    {
        if (this.endPoint != null) return;
        this.endPoint = GameObject.Find("EndPoint").GetComponent<Transform>();
        Debug.LogWarning(transform.name + " LoadEndPoint", gameObject);
    }

    protected void LoadStartPoint()
    {
        if (this.startPoint != null) return;
        this.startPoint=GameObject.Find("StartPoint").GetComponent<Transform>();
        Debug.LogWarning(transform.name + " LoadStartPoint", gameObject);
    }

    protected override void Start()
    {
        base.Start();
        this.AddCurrency();
    }

    protected void AddCurrency()
    {
        this.currency = 100;
    }

    //Tăng tiền
    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    //Tiêu tiền
    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            //Buy item
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("You don't have enough to purchase this item");
            return false;
        }
    }
}
