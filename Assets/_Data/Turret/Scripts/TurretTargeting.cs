using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : SaiBehavior
{
    [SerializeField] protected EnemyCtrl targetEnemy;
    [SerializeField] protected List<Targetable> enemies;

    protected virtual void OnTriggerEnter(Collider other)
    {
        Targetable targetable = other.GetComponent<Targetable>();
        if (targetable == null) return;
        this.enemies.Add(targetable);
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        Targetable targetable = other.GetComponent<Targetable>();
        if (targetable == null) return;
        this.enemies.Remove(targetable);
    }
}
