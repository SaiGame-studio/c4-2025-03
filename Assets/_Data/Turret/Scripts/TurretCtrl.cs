using System.Collections.Generic;
using UnityEngine;

public class TurretCtrl : SaiBehaviour
{
    [SerializeField] protected TurretTargeting turretTargeting;
    public TurretTargeting TurretTargeting => turretTargeting;

    [SerializeField] protected TurretShooting turretShooting;
    public TurretShooting TurretShooting => turretShooting;

    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    [SerializeField] protected TowerLevel level;
    public TowerLevel Level => level;

    [SerializeField] protected List<FirePoint> firePoints;
    public List<FirePoint> FirePoints => firePoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadTurretTargeting();
        this.LoadTurretShootings();
        this.LoadFirePoints();
        this.LoadLevel();
    }

    protected virtual void LoadLevel()
    {
        if (this.level != null) return;
        this.level = GetComponentInChildren<TowerLevel>();
        Debug.Log(transform.name + ": LoadLevel", gameObject);
    }

    protected virtual void LoadTurretShootings()
    {
        if (this.turretShooting != null) return;
        this.turretShooting = GetComponentInChildren<TurretShooting>();
        Debug.Log(transform.name + ": LoadTurretShootings", gameObject);
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
