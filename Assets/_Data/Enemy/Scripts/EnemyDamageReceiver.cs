using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy")]
    [SerializeField] protected EnemyCtrl ctrl;
    protected float forceAmount = 5.0f;

    protected virtual void LateUpdate()
    {
        this.UpdateDeadAnimation();
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

    protected virtual void UpdateDeadAnimation()
    {
        this.ctrl.Animator.SetBool("IsAlive", this.isAlive);
    }

    protected override void OnDead()
    {
        base.OnDead();
        this.DropItems();
        Invoke(nameof(this.Despawn), 4f);
    }

    protected virtual void DropItems()
    {
        this.DropItem(ItemCode.Gold);
        this.DropItem(ItemCode.PlayerExp);
    }

    protected virtual void DropItem(ItemCode itemCode)
    {
        ItemDropCtrl prefab = ItemDropSpawnerCtrl.Instance.Spawner.PoolPrefabs.GetByName(itemCode.ToString());
        ItemDropCtrl newItemDrop = ItemDropSpawnerCtrl.Instance.Spawner.Spawn(prefab);

        Vector3 dropPosition = transform.position;
        dropPosition.y += 2;
        newItemDrop.transform.position = dropPosition;
        newItemDrop.SetActive(true);

        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = Mathf.Abs(randomDirection.y);
        newItemDrop.Rigidbody.AddForce(randomDirection * forceAmount, ForceMode.Impulse);
    }

    protected virtual void Despawn()
    {
        this.ctrl.Despawn.DoDespawn();
    }
}
