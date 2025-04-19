using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : SaiBehaviour
{
    [SerializeField] protected Targetable nearest;
    public Targetable Nearest => nearest;

    [SerializeField] protected List<Targetable> enemies;

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
        this.enemies.Add(targetable);
    }

    protected virtual void RemoveEnemy(Collider other)
    {
        Targetable targetable = other.GetComponent<Targetable>();
        if (targetable == null) return;
        this.enemies.Remove(targetable);
    }

    protected virtual void FindNearest()
    {
        float nearestDistance = Mathf.Infinity;
        float enemyDistance;
        foreach (Targetable target in this.enemies)
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
