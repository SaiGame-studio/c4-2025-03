using UnityEngine;

public class WeaponCtrl : SaiBehaviour
{
    [SerializeField] protected FirePoint firePoint;
    public FirePoint FirePoint => firePoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFirePoint();
    }

    protected virtual void LoadFirePoint()
    {
        if (this.firePoint != null) return;
        this.firePoint = transform.GetComponentInChildren<FirePoint>();
        Debug.Log(transform.name + ": LoadFirePoint", gameObject);
    }


}
