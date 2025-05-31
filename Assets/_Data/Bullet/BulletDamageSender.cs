using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.LogWarning(transform.name + ": LoadBulletCtrl", gameObject);
    }

    public override void Despawn()
    {
        this.SpawnHitEffect();
        this.ctrl.Despawn.DoDespawn();
    }

    protected virtual void SpawnHitEffect()
    {
        string hitName = this.ctrl.GetHitName();
        if (hitName == null) return;
        BulletCtrl prefab = BulletSpawnerCtrl.Instance.Spawner.PoolPrefabs.GetByName(hitName);
        BulletCtrl newObj = BulletSpawnerCtrl.Instance.Spawner.Spawn(prefab, transform.position);
        newObj.transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
        newObj.SetActive(true);
    }
}
