using UnityEngine;

public class SaiBehavior : MonoBehaviour
{
    protected virtual void Start()
    {
        //TODO: for override
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        //TODO: for override
    }
}
