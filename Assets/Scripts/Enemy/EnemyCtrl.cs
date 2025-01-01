using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : TDMonoBehaviour
{
    [SerializeField] protected EnemySpawner spawner;
    public EnemySpawner Spawner=>spawner;
    [SerializeField] protected EnemyMovement enemyMovement;
    public EnemyMovement EnemyMovement => enemyMovement;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadEnemyMovement();
    }

    protected void LoadEnemyMovement()
    {
        if (this.enemyMovement != null) return;
        this.enemyMovement = transform.Find("Prefabs").GetComponentInChildren<EnemyMovement>();
        Debug.LogWarning(transform.name + ": LoadEnemyMovement", gameObject);
    }

    protected void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner=transform.GetComponent<EnemySpawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }
}
