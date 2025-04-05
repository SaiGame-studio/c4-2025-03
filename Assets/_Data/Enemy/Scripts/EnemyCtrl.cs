using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : SaiBehavior
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Animator animator;

    public NavMeshAgent Agent => agent;
    public Animator Animator => animator;

    int currentHp = 10;
    public float weight = 1f;

    protected override void Awake()
    {
        base.Awake();
        this.RandomWeight();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAgent();
        this.LoadAnimator();
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


    bool IsDead()
    {
        if (this.currentHp > 0) return false;
        else return true;
    }

    bool IsAlive()
    {
        return this.currentHp > 0;
    }

    int GetCurrenHp()
    {
        return this.currentHp;
    }

    void RandomWeight()
    {
        this.weight = UnityEngine.Random.Range(0.5f, 4f);
    }
}
