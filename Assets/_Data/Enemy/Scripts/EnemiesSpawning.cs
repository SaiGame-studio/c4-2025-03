using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawning : SaiBehaviour
{
    [SerializeField] protected EnemiesSpawnerCtrl ctrl;
    [SerializeField] protected Point pointToStart;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 2;

    protected virtual void FixedUpdate()
    {
        this.Spawning();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GetComponent<EnemiesSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadCtrl", gameObject);
    }

    protected virtual void Spawning()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;

        EnemyCtrl enemyPrefab = this.ctrl.Spawner.PoolPrefabs.GetByName("Archer");
        EnemyCtrl newEnemy = this.ctrl.Spawner.Spawn(enemyPrefab);
        newEnemy.transform.position = transform.position;
        newEnemy.Moving.SetPointToGo(this.pointToStart);
        newEnemy.SetActive(true);
    }
}
