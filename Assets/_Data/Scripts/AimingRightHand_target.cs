using UnityEngine;

public class AimingRightHand_target : SaiBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.2215742f, 0.177404f, 0.3095092f);
        transform.localRotation = Quaternion.Euler(-3.209f, -74.658f, -92.304f);
    }
}
