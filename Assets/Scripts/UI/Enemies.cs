using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemies : BaseLoadTextM
{
    [Header("Enemies")]
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
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
        base.LoadTextMeshPro();
        if (this.textMeshPro != null) return;
        this.textMeshPro = transform.Find("EnemiesAlive - text").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadTextMeshPro", gameObject);
    }

    protected override void OnGUI()
    {
        base.OnGUI();
        this.textMeshPro.text = enemyCtrl.Spawner.EnemiesAlive.ToString();
    }
}
