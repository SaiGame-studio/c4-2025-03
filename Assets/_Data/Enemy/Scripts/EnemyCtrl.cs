using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : PoolObj
{
    [Header("Enemy")]
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;

    [SerializeField] protected Transform model;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    [SerializeField] protected EnemyDamageReceiver damageReceiver;
    public EnemyDamageReceiver DamageReceiver => damageReceiver;

    [SerializeField] protected EnemyMoving moving;
    public EnemyMoving Moving => moving;

    protected virtual void OnEnable()
    {
        this.Reborn();
    }


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
        this.damageReceiver = GetComponentInChildren<EnemyDamageReceiver>();
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
        this.model = transform.Find("Model");
        this.animator = this.model.GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator", gameObject);
    }

    public override string GetName()
    {
        return "Enemy";
    }

    protected virtual void Reborn()
    {
        this.model.transform.localPosition = Vector3.zero;
    }
}
