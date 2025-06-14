using UnityEngine;

public class EnemyMoving : SaiBehaviour
{
    [SerializeField] protected EnemyCtrl ctrl;
    [SerializeField] protected Point pointToGo;
    [SerializeField] protected bool IsWalking = true;
    [SerializeField] protected float targetDistance = 0;
    [SerializeField] protected float stopDistance = 1;
    [SerializeField] protected bool isReachTarget = false;

    protected void LateUpdate()
    {
        this.MoveToTarget();
        this.UpdateAnimator();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected virtual void MoveToTarget()
    {
        if (!this.CanMove())
        {
            this.StopMoving();
            return;
        }

        Vector3 postion = this.pointToGo.transform.position;

        this.targetDistance = Vector3.Distance(transform.position, this.pointToGo.transform.position);
        if (this.targetDistance < this.stopDistance)
        {
            this.ctrl.Agent.isStopped = true;
            this.LoadNextPoint();
        }
        else
        {
            this.ctrl.Agent.isStopped = false;
            this.ctrl.Agent.SetDestination(postion);
        }
    }

    protected virtual bool CanMove()
    {
        bool canMove = true;
        if (this.pointToGo == null) canMove = false;
        if (this.ctrl.DamageReceiver != null && !this.ctrl.DamageReceiver.IsAlive()) canMove = false;

        return canMove;
    }

    protected virtual void StopMoving()
    {
        this.ctrl.Agent.isStopped = true;
    }

    protected virtual void UpdateAnimator()
    {
        this.IsWalking = !this.ctrl.Agent.isStopped;
        if(this.ctrl.Animator != null) this.ctrl.Animator.SetBool("IsWalking", this.IsWalking);
    }

    protected virtual void LoadNextPoint()
    {
        this.pointToGo = this.pointToGo.NextPoint;
    }

    public virtual void SetPointToGo(Point point)
    {
        this.pointToGo = point;
    }
}
