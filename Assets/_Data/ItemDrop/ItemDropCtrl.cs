using UnityEngine;

public abstract class ItemDropCtrl : PoolObj
{
    [SerializeField] protected Rigidbody _rigidbody;
    public Rigidbody Rigidbody => _rigidbody;
    public abstract ItemCode GetItemCode();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        Debug.LogWarning(transform.name + ": LoadRigibody", gameObject);
    }


}
