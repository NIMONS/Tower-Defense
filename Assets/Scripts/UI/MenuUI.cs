using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MenuUI : TDMonoBehaviour
{
    [Header("Referencs")]
    [SerializeField] protected TextMeshProUGUI currencyUI;
    [SerializeField] protected Animator _animator;


    private bool isMenuOpen = true;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCurrencyUI();
        this.LoadAnimator();
    }

    protected void LoadAnimator()
    {
        if (this._animator != null) return;
        this._animator = transform.GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator", gameObject);
    }

    protected void LoadCurrencyUI()
    {
        if (this.currencyUI != null) return;
        this.currencyUI=transform.Find("Currency").GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadCurrencyUI", gameObject);
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        _animator.SetBool("MenuOpen", isMenuOpen);
    }

    private void OnGUI()
    {
        currencyUI.text=LevelManager.Instance.currency.ToString();
    }

}
