using UnityEngine;

public class HideMouse : MonoBehaviour
{

    protected bool isHide = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.ToogleMouse();
        }
    }

    protected virtual void ToogleMouse()
    {
        this.isHide = !this.isHide;
        if (this.isHide)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
