using UnityEngine;

public class Projectile2Ctrl : BulletCtrl
{
    [SerializeField] protected string objName = BulletCode.Projecttile2.ToString();

    public override string GetName()
    {
        return this.objName;
    }

    public override string GetHitName()
    {
        return BulletCode.Hit2.ToString();
    }
}
