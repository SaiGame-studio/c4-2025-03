using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawning : SaiBehaviour
{
    [SerializeField] protected EnemiesSpawnerCtrl ctrl;
    [SerializeField] protected Point pointToStart;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 2;
    [SerializeField] protected float limit = 1;
    [SerializeField] protected float limitCount = 0;

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
        if (this.limitCount > this.limit) return;

        EnemyCtrl enemyPrefab = this.ctrl.Spawner.PoolPrefabs.GetByName("Archer");
        EnemyCtrl newEnemy = this.ctrl.Spawner.Spawn(enemyPrefab);
        newEnemy.transform.position = transform.position;
        if(newEnemy.Moving != null) newEnemy.Moving.SetPointToGo(this.pointToStart);
        newEnemy.SetActive(true);
        this.limitCount++;
    }
}
