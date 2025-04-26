using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_hint : SaiBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.319f, 0.061f, 0.143f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
