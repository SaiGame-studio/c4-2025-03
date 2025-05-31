using UnityEngine;

public class DamageReceiver : SaiBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected bool isAlive = true;

    [SerializeField] protected int currentHp = 10;
    public int CurrentHp => currentHp;

    [SerializeField] protected int maxHp = 7;
    public int MaxHp => maxHp;

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
        if (!this.IsAlive()) return;
        DamageSender damageSender = trigger.GetComponent<DamageSender>();
        if (damageSender == null) return;
        damageSender.Despawn();
        this.Deduct(damageSender.GetDamage());
        if (!this.IsAlive())
        {
            this.OnDead();
        }
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

    protected virtual void OnDead()
    {
        //Donothing
    }
}
