using UnityEngine;

public class BulletDespawn : DespawnBase
{
    [SerializeField] protected BulletCtrl ctrl;
    [SerializeField] protected float delay = 7;

    private void OnEnable()
    {
        Invoke(nameof(DoDespawn), this.delay);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCltr();
    }

    protected virtual void LoadCltr()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.LogWarning(transform.name + ": LoadCltr", gameObject);
    }

    public override void DoDespawn()
    {
        BulletSpawnerCtrl.Instance.Spawner.Despawn(this.ctrl);
    }
}
