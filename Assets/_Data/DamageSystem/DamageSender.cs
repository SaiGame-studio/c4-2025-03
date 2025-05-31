using UnityEngine;

public abstract class DamageSender : SaiBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual int GetDamage()
    {
        return this.damage;
    }

    public abstract void Despawn();
}
