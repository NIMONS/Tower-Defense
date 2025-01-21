using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Tower
{
    public string nameTurret;
    public int costBuy;
    public int costSell;
	public GameObject turretPrefab;

    public Tower(string name, int cost, int costSell ,GameObject prefab)
    {
        this.nameTurret = name;
        this.costBuy = cost;
        this.costSell = costSell;
        this.turretPrefab = prefab;
    }
}
