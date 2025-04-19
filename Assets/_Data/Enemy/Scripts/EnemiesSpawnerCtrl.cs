using UnityEngine;

public class EnemiesSpawnerCtrl : SaiSingleton<EnemiesSpawnerCtrl>
{
    [SerializeField] protected EnemiesSpawner spawner;
    public EnemiesSpawner Spawner => spawner;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<EnemiesSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }
}
