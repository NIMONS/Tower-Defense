using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUI : TDMonoBehaviour
{
    [Header("References")]
    [SerializeField] protected TextMeshProUGUI textHP;
    public TextMeshProUGUI TextHP => textHP;

    [Header("Attributes")]
    [SerializeField] protected int maxHP = 20;
    [SerializeField] protected int currentHP;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMeshProUGUI();
    }

    protected void LoadTextMeshProUGUI()
    {
        if (this.textHP != null) return;
        this.textHP = transform.Find("InfoPlayer-Image").Find("InfoHeartUI").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadTextMeshProUGUI", gameObject);
    }

    protected override void Start()
    {
        base.Start();
        this.currentHP = this.maxHP;
    }

    protected override void Update()
    {
        base.Update();
        this.UpdateHP();
        this.textHP.text = this.currentHP.ToString();
    }

    public void UpdateHP()
    {
        
    }

    public void minusHP(int minushp)
    {
        this.currentHP -=minushp;
        if (this.currentHP == 0)
        {
            this.currentHP = 0;
            Debug.Log("You lose");
        }
    }

    //private void OnGUI()
    //{
    //}
}
