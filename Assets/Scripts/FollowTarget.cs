using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : TDMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;
    protected void FixedUpdate()
    {
        this.Following();
    }

    protected void Following()
    {
        if (this.target == null) return;
        transform.position=Vector3.Lerp(transform.position,target.position,speed*Time.fixedDeltaTime);
    }
}
