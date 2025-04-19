using UnityEngine;

public class BulletSpawnerCtrl : SaiSingleton<BulletSpawnerCtrl>
{
    [SerializeField] protected BulletSpawner spawner;
    public BulletSpawner Spawner => spawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<BulletSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }
}
