using System.Collections.Generic;
using UnityEngine;

public class TurretCtrl : SaiBehaviour
{
    [SerializeField] protected TurretTargeting turretTargeting;
    public TurretTargeting TurretTargeting => turretTargeting;

    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    [SerializeField] protected List<FirePoint> firePoints;
    public List<FirePoint> FirePoints => firePoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadTurretTargeting();
        this.LoadFirePoints();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.rotator = this.model.Find("Rotator");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadTurretTargeting()
    {
        if (this.turretTargeting != null) return;
        this.turretTargeting = transform.GetComponentInChildren<TurretTargeting>();
        Debug.Log(transform.name + ": LoadTurretTargeting", gameObject);
    }

    protected virtual void LoadFirePoints()
    {
        if (this.firePoints.Count > 0) return;
        FirePoint[] points = transform.GetComponentsInChildren<FirePoint>();
        this.firePoints = new List<FirePoint>(points);
        Debug.Log(transform.name + ": LoadTowerTargeting", gameObject);
    }
}
