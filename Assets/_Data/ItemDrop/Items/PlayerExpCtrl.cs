using UnityEngine;

public class PlayerExpCtrl : ItemDropCtrl
{
    public override ItemCode GetItemCode()
    {
        return ItemCode.PlayerExp;
    }

    public override string GetName()
    {
        return ItemCode.PlayerExp.ToString();
    }
}
