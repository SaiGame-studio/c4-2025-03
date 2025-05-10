using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAbstract : SaiBehaviour
{
    [Header("Abstract")]
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected void LateUpdate()
    {
        this.Attacking();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected abstract void Attacking();

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.parent.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
}
