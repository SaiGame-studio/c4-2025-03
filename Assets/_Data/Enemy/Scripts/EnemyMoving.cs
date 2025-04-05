using UnityEngine;

public class EnemyMoving : SaiBehavior
{
    [SerializeField] protected GameObject targetToMove;
    [SerializeField] protected EnemyCtrl ctrl;
    [SerializeField] protected bool IsWalking = true;
    [SerializeField] protected float targetDistance = 0;
    [SerializeField] protected float stopDistance = 1;

    protected void LateUpdate()
    {
        this.MoveToTarget();
        this.UpdateAnimator();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadTarget();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected virtual void LoadTarget()
    {
        if (this.targetToMove != null) return;
        this.targetToMove = GameObject.Find("TargetToMove");
        Debug.LogWarning(transform.name + ": LoadTarget", gameObject);
    }

    protected virtual void MoveToTarget()
    {
        Vector3 postion = this.targetToMove.transform.position;

        this.targetDistance = Vector3.Distance(transform.position, this.targetToMove.transform.position);
        if (this.targetDistance < this.stopDistance)
        {
            this.ctrl.Agent.isStopped = true;
        }
        else
        {
            this.ctrl.Agent.isStopped = false;
            this.ctrl.Agent.SetDestination(postion);
        }
    }

    protected virtual void UpdateAnimator()
    {
        this.IsWalking = !this.ctrl.Agent.isStopped;
        this.ctrl.Animator.SetBool("IsWalking", this.IsWalking);
    }

}
