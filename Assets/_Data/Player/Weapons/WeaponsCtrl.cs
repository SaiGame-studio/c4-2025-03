using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsCtrl : SaiBehaviour
{
    [SerializeField] protected List<WeaponCtrl> weapons;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeapons();
    }

    protected virtual void LoadWeapons()
    {
        if (this.weapons.Count > 0) return;
        this.weapons = new List<WeaponCtrl>(GetComponentsInChildren<WeaponCtrl>());
        Debug.Log(transform.name + ": LoadWeapons", gameObject);
    }

    public virtual WeaponCtrl GetCurrent()
    {
        return this.weapons[0];
    }
}
