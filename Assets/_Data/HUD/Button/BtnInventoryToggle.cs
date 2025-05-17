using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInventoryToggle : ButttonAbstract
{
    protected override void OnClick()
    {
        Debug.Log("Inventory");
        InventoryUI.Instance.Toggle();
    }
}
