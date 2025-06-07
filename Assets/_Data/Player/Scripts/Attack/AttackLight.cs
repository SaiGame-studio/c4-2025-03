using UnityEngine;

public class AttackLight : AttackAbstract
{

    [SerializeField] protected string bulletName = "Projectile_2";
    [SerializeField] protected string muzzleName = "Muzzle_2";
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 1;
    [SerializeField] protected SoundCode shootSfxName = SoundCode.LaserOneShoot;

    protected override void Attacking()
    {
        this.timer += Time.deltaTime;
        if (!InputManager.Instance.IsAttackLight()) return;
        if (this.timer < this.delay) return;
        this.timer = 0;

        FirePoint firePoint = this.GetFirePoint();

        Vector3 startPoint = this.playerCtrl.CrosshairPointer.transform.position;
        Vector3 endPoint = firePoint.transform.position;
        Vector3 rotatorDirection = (startPoint - endPoint).normalized;

        this.SpawnBullet(firePoint, rotatorDirection);
        this.SpawnMuzzle(firePoint, rotatorDirection);
        this.SpawnSound();
    }

    protected virtual void SpawnMuzzle(FirePoint firePoint, Vector3 rotatorDirection)
    {
        BulletCtrl muzzlePrefab = BulletSpawnerCtrl.Instance.Spawner.PoolPrefabs.GetByName(this.muzzleName);
        BulletCtrl newMuzzle = BulletSpawnerCtrl.Instance.Spawner.Spawn(muzzlePrefab, firePoint.transform.position);
        newMuzzle.transform.rotation = Quaternion.LookRotation(rotatorDirection.normalized);
        newMuzzle.transform.parent = transform;
        newMuzzle.SetActive(true);
    }

    protected virtual void SpawnBullet(FirePoint firePoint, Vector3 rotatorDirection)
    {
        BulletCtrl bulletPrefab = BulletSpawnerCtrl.Instance.Spawner.PoolPrefabs.GetByName(this.bulletName);
        BulletCtrl newBullet = BulletSpawnerCtrl.Instance.Spawner.Spawn(bulletPrefab, firePoint.transform.position);
        newBullet.transform.rotation = Quaternion.LookRotation(rotatorDirection.normalized);
        newBullet.SetActive(true);
    }

    protected virtual FirePoint GetFirePoint()
    {
        return this.playerCtrl.WeaponsCtrl.GetCurrent().FirePoint;
    }

    protected virtual void SpawnSound()
    {
        Vector3 position = transform.position;
        SFXCtrl newSfx = SoundManager.Instance.CreateSfx(this.shootSfxName);
        newSfx.transform.position = position;
        newSfx.gameObject.SetActive(true);
    }
}
