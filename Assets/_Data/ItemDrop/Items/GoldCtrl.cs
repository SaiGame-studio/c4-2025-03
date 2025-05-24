using UnityEngine;

public class GoldCtrl : ItemDropCtrl
{
    public override ItemCode GetItemCode()
    {
        return ItemCode.Gold;
    }

    public override string GetName()
    {
        return ItemCode.Gold.ToString();
    }
}
