using UnityEngine;

public class EnemyDespawn : DespawnBase
{
    [SerializeField] protected EnemyCtrl ctrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCltr();
    }

    protected virtual void LoadCltr()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadCltr", gameObject);
    }

    public override void DoDespawn()
    {
        EnemiesSpawnerCtrl.Instance.Spawner.Despawn(this.ctrl);
    }
}
