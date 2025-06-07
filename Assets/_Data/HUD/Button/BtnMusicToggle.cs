using UnityEngine;

public class BtnMusicToggle : ButttonAbstract
{
    protected virtual void LateUpdate()
    {
        this.HotkeyToogleMusic();
    }

    protected override void OnClick()
    {
        SoundManager.Instance.ToggleMusic();
    }

    protected virtual void HotkeyToogleMusic()
    {
        if (InputManager.Instance.IsToogleMusic) SoundManager.Instance.ToggleMusic();
    }
}
