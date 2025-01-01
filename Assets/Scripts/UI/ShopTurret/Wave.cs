using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wave : BaseLoadTextM
{
    [Header("References")]
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMeshPro();
        this.LoadEnemyCtrl();
    }

    protected void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = GameObject.FindObjectOfType<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected override void LoadTextMeshPro()
    {
        if (this.textMeshPro != null) return;
        this.textMeshPro = transform.Find("CurrentWave").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadTextMeshPro", gameObject);
    }

    protected override void OnGUI()
    {
        this.textMeshPro.text = this.enemyCtrl.Spawner.currentWave.ToString();
    }
}
