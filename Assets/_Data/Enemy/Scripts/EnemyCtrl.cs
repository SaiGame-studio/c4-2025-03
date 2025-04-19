using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : PoolObj
{
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;

    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;

    [SerializeField] protected EnemyMoving moving;
    public EnemyMoving Moving => moving;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAgent();
        this.LoadAnimator();
        this.LoadDamageReceiver();
        this.LoadEnemyMoving();
    }

    protected virtual void LoadEnemyMoving()
    {
        if (this.moving != null) return;
        this.moving = GetComponentInChildren<EnemyMoving>();
        Debug.LogWarning(transform.name + ": LoadEnemyMoving", gameObject);
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(transform.name + ": LoadDamageReceiver", gameObject);
    }

    protected virtual void LoadAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        Debug.LogWarning(transform.name + ": LoadAgent", gameObject);
    }


    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.Find("Model").GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator", gameObject);
    }

    public override string GetName()
    {
        return "Enemy";
    }
}
