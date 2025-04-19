using System.Collections.Generic;
using UnityEngine;

public class EnemySorting : SaiBehaviour
{
    [SerializeField] protected EnemyManager manager;
    [SerializeField] protected List<EnemyCtrl> sortEnemies;

    protected virtual void Start()
    {
        this.SortEnemy();
    }

    public void SortEnemy()
    {
        sortEnemies = new List<EnemyCtrl>(manager.enemies);
        sortEnemies.Sort((a, b) => a.weight.CompareTo(b.weight));
    }
}
