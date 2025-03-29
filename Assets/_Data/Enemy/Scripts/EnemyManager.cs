using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SaiBehavior
{
    public EnemyCtrl minEnemy;
    public EnemyCtrl maxEnemy;
    public List<EnemyCtrl> enemies;

    private void Start()
    {
        this.ShowEnemey();
        this.FindMinEnemy();
    }

    protected override void LoadComponents()
    {
        //base.LoadComponents();
        this.LoadEnemeies();
    }

    protected virtual void LoadEnemeies()
    {
        if (this.enemies.Count > 0) return;
        EnemyCtrl enemyCtrl;
        foreach (Transform child in transform)
        {
            enemyCtrl = child.GetComponent<EnemyCtrl>();
            this.enemies.Add(enemyCtrl);
        }
        Debug.LogWarning(transform.name + ": LoadEnemeies", gameObject);
    }

    void ShowEnemey()
    {
        foreach (EnemyCtrl enemy in this.enemies)
        {
            Debug.Log(enemy.name + ": " + enemy.weight);
        }
    }

    void FindMinEnemy()
    {
        float minWeight = Mathf.Infinity;
        float maxWeight = 0;

        foreach (EnemyCtrl enemy in this.enemies)
        {
            if (enemy.weight < minWeight)
            {
                minWeight = enemy.weight;
                this.minEnemy = enemy;
            }

            if (enemy.weight >= maxWeight)
            {
                maxWeight = enemy.weight;
                this.maxEnemy = enemy;
            }
        }

        Debug.Log("Min Enemy:" + this.minEnemy.name + " - " + this.minEnemy.weight);
        Debug.Log("Max Enemy:" + this.maxEnemy.name + " - " + this.maxEnemy.weight);
    }
}
