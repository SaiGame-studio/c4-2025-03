using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtPlayerLevel : TextLevel
{
    protected override string GetLevel()
    {
        return PlayerCtrl.Instance.Level.CurrentLevel.ToString();
    }
}
