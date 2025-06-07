using UnityEngine;

public class BtnSettingToogle : ButttonAbstract
{
    protected virtual void LateUpdate()
    {
        this.HotkeyToogleMusic();
    }

    protected override void OnClick()
    {
        UISetting.Instance.Toggle();
    }

    protected virtual void HotkeyToogleMusic()
    {
        //if (InputManager.Instance.isToogleSetting) UISetting.Instance.Toggle();
    }
}
