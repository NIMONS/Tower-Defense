using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHP : TDMonoBehaviour
{
    [SerializeField] protected float maxHP=100;
    [SerializeField] protected float currentHP = 70;
    [SerializeField] protected Slider slider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSilder();
    }

    protected void LoadSilder()
    {
        if (this.slider != null) return;
        this.slider=transform.GetComponent<Slider>();
        Debug.LogWarning(transform.name + ": LoadSilder", gameObject);
    }

    private void FixedUpdate()
    {
        this.HPShowing();
    }

    protected void HPShowing()
    {
        float hpPercent = this.currentHP / this.maxHP;
        this.slider.value = hpPercent;
    }
}
