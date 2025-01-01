using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnUpgrade : TDMonoBehaviour
{
    [SerializeField] protected Transform Notification;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNotification();
    }

    protected void LoadNotification()
    {
        if (this.Notification != null) return;
        this.Notification=transform.parent.parent.parent.Find("Notification").GetComponent<Transform>();
        Debug.LogWarning(transform.name + ": LoadNotification", gameObject);
    }

    public void UpgradeTurret()
    {
        Debug.Log("Turret upgrade");
        this.Notification.gameObject.SetActive(true);
    }
}
