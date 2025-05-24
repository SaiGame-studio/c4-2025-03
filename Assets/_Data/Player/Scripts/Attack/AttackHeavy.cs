using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHeavy : AttackAbstract
{
    [SerializeField] protected string bulletName = "BulletHeavy";
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 1;

    protected override void Attacking()
    {

        this.timer += Time.deltaTime;
        if (!InputManager.Instance.IsAttackHeavy()) return;
        if (this.timer < this.delay) return;
        this.timer = 0;

        FirePoint firePoint = this.GetFirePoint();

        Vector3 startPoint = this.playerCtrl.CrosshairPointer.transform.position;
        Vector3 endPoint = firePoint.transform.position;
        Vector3 rotatorDirection = (startPoint - endPoint).normalized;

        BulletCtrl bulletPrefab = BulletSpawnerCtrl.Instance.Spawner.PoolPrefabs.GetByName(this.bulletName);
        Debug.Log(bulletPrefab.name);
        BulletCtrl newBullet = BulletSpawnerCtrl.Instance.Spawner.Spawn(bulletPrefab, firePoint.transform.position);
        newBullet.transform.rotation = Quaternion.LookRotation(rotatorDirection.normalized);
        newBullet.SetActive(true);
    }

    protected virtual FirePoint GetFirePoint()
    {
        return this.playerCtrl.WeaponsCtrl.GetCurrent().FirePoint;
    }
}
