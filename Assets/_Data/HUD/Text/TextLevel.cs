using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TextLevel : Text3DAbstact
{
    protected virtual void FixedUpdate()
    {
        this.UpdateLevel();
    }

    protected virtual void UpdateLevel()
    {
        this.textPro.text = "Lvl: " + this.GetLevel();
    }

    protected abstract string GetLevel();
}
