using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtTurretLevel : TextLevel
{
    [SerializeField] protected TurretCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponentInParent<TurretCtrl>();
        Debug.Log(transform.name + ": LoadTowerCtrl", gameObject);
    }

    protected override string GetLevel()
    {
        return this.ctrl.Level.CurrentLevel.ToString();
    }
}
