using UnityEngine;

public class DamageReceiver : SaiBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected int currentHp = 10;
    [SerializeField] protected int maxHp = 7;
    [SerializeField] protected bool isAlive = true;

    protected virtual void OnEnable()
    {
        this.Reborn();
    }

    protected virtual void OnTriggerEnter(Collider trigger)
    {
        this.ApplyDamage(trigger);
    }

    protected virtual void ApplyDamage(Collider trigger)
    {
        BulletDamageSender damageSender = trigger.GetComponent<BulletDamageSender>();
        if (damageSender == null) return;
        damageSender.Despawn();
        this.Deduct(damageSender.GetDamage());
        this.IsAlive();
    }

    protected virtual void Deduct(int damage)
    {
        this.currentHp -= damage;
        if (this.currentHp < 0) this.currentHp = 0;
    }

    protected virtual void Reborn()
    {
        this.currentHp = this.maxHp;
    }

    public virtual bool IsAlive()
    {
        if (this.currentHp <= 0) this.isAlive = false;
        else this.isAlive = true;
        return this.isAlive;
    }
}
