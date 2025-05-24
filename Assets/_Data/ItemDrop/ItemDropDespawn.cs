using UnityEngine;

public class ItemDropDespawn : DespawnBase
{
    [SerializeField] protected ItemDropCtrl ctrl;
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
        this.ctrl = transform.parent.GetComponent<ItemDropCtrl>();
        Debug.LogWarning(transform.name + ": LoadCltr", gameObject);
    }

    public override void DoDespawn()
    {
        ItemCode itemCode = this.ctrl.GetItemCode();
        InventoryManager.Instance.AddItem(itemCode, 1);
        ItemDropSpawnerCtrl.Instance.Spawner.Despawn(this.ctrl);
    }
}
