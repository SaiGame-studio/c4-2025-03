using UnityEngine;

public class SaiBehavior : MonoBehaviour
{
    protected void Awake()
    {
        this.LoadComponents();
    }

    protected void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        //TODO: for override
    }
}
