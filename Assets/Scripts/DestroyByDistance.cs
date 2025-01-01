using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByDistance : TDMonoBehaviour
{
    [SerializeField] protected List<Transform> bullets;
    public List<Transform> Bullets=>bullets;
    [SerializeField] protected Transform cameraMain;
    [SerializeField] protected float disLimit = 20f;
    [SerializeField] protected float distance = 0f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected override void Update()
    {
        base.Update();
        this.DestroyBullet();
    }

    protected void LoadCamera()
    {
        if (this.cameraMain != null) return;
        this.cameraMain=GameObject.FindObjectOfType<Camera>().GetComponent<Transform>();
        //Debug.LogWarning(transform.name + ": LoadCamera", gameObject);
    }

    public void DestroyBullet()
    {
        foreach (Transform t in bullets)
        {
            if (t == null)
            {
                this.bullets.Remove(t);
                return;
            }
            this.distance=Vector2.Distance(t.position, cameraMain.position);
            if(distance>this.disLimit)Destroy(t.gameObject);
        }
    }
}
