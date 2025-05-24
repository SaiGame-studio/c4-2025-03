using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : SaiBehaviour
{
    [SerializeField] protected EnemyCtrl nearest;
    public EnemyCtrl Nearest => nearest;

    [SerializeField] protected List<EnemyCtrl> enemies;

    protected virtual void FixedUpdate()
    {
        this.FindNearest();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        this.AddEnemy(other);
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        this.RemoveEnemy(other);
    }

    protected virtual void AddEnemy(Collider other)
    {
        Targetable targetable = other.GetComponent<Targetable>();
        if (targetable == null) return;
        EnemyCtrl enemyCtrl = targetable.GetComponentInParent < EnemyCtrl > ();
        this.enemies.Add(enemyCtrl);
    }

    protected virtual void RemoveEnemy(Collider other)
    {
        EnemyCtrl enemyCtrl = other.GetComponentInParent<EnemyCtrl>();
        if (enemyCtrl == null) return;
        this.enemies.Remove(enemyCtrl);
    }

    protected virtual void FindNearest()
    {
        float nearestDistance = Mathf.Infinity;
        float enemyDistance;
        foreach (EnemyCtrl target in this.enemies)
        {

            enemyDistance = Vector3.Distance(transform.position, target.transform.position);
            if (enemyDistance < nearestDistance)
            {
                nearestDistance = enemyDistance;
                this.nearest = target;
            }
        }

        if (!this.enemies.Contains(this.nearest)) this.nearest = null;
    }
}
