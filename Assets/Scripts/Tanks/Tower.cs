using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Tower
{
    public string nameTurret;
    public int cost;
    public GameObject turretPrefab;

    public Tower(string name, int cost, GameObject prefab)
    {
        this.nameTurret = name;
        this.cost = cost;
        this.turretPrefab = prefab;
    }
}
