using UnityEngine;

public class DamageSender : SaiBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual int GetDamage()
    {
        return this.damage;
    }
}
