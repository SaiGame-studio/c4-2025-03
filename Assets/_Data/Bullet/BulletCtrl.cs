using UnityEngine;

public class BulletCtrl : PoolObj
{
    public virtual string GetHitName()
    {
        return null;
    }

    public override string GetName()
    {
        return BulletCode.Bullet.ToString();
    }
}
