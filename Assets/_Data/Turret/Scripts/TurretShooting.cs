using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : SaiBehaviour
{
    [SerializeField] protected TurretCtrl ctrl;
    [SerializeField] protected Targetable target;
    [SerializeField] protected float rotationSpeed = 4f;
    [SerializeField] protected float shootSpeed = 1f;
    [SerializeField] protected int currentFirePoint = 0;

    public BulletCtrl bulletPrefab;

    protected override void Start()
    {
        base.Start();
        this.TargetLoading();
        this.Shooting();
    }

    protected virtual void FixedUpdate()
    {
        this.Looking();
    }

    protected virtual void Looking()
    {
        if (this.target == null) return;
        Vector3 directionToTarget = this.target.transform.position - this.ctrl.Rotator.position;
        Vector3 newDirection = Vector3.RotateTowards(
            this.ctrl.Rotator.forward,
            directionToTarget,
            rotationSpeed * Time.fixedDeltaTime,
            0.0f
        );

        this.ctrl.Rotator.rotation = Quaternion.LookRotation(newDirection);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTurretCtrl();
    }

    protected virtual void LoadTurretCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.parent.GetComponent<TurretCtrl>();
        Debug.Log(transform.name + ": LoadTurretCtrl", gameObject);
    }

    protected virtual void TargetLoading()
    {
        this.target = this.ctrl.TurretTargeting.Nearest;
        Invoke(nameof(this.TargetLoading), 1f);
    }

    protected virtual void Shooting()
    {
        Invoke(nameof(this.Shooting), this.shootSpeed + Random.Range(-0.1f, 0.1f));

        if (this.target == null) return;

        Debug.Log("Shooting");

        FirePoint firePoint = this.GetFirePoint();
        Vector3 rotatorDirection = this.ctrl.Rotator.transform.forward;

        //Transform oldBullet = Instantiate(this.oldBulletPrefab, firePoint.transform.position, Quaternion.identity);
        //oldBullet.rotation = Quaternion.LookRotation(rotatorDirection.normalized);

        BulletCtrl newBullet = BulletSpawnerCtrl.Instance.Spawner.Spawn(this.bulletPrefab, firePoint.transform.position);
        newBullet.transform.rotation = Quaternion.LookRotation(rotatorDirection.normalized);
        newBullet.SetActive(true);
    }

    protected virtual FirePoint GetFirePoint()
    {
        FirePoint firePoint = this.ctrl.FirePoints[this.currentFirePoint];
        this.currentFirePoint++;
        if (this.currentFirePoint == this.ctrl.FirePoints.Count) this.currentFirePoint = 0;
        return firePoint;
    }
}
