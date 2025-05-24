using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelAbstract : SaiBehaviour
{
    [SerializeField] protected int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    [SerializeField] protected int maxLevel = 100;
    [SerializeField] protected int nextLevelExp;
    [SerializeField] protected float baseExp = 10f;
    [SerializeField] protected float exponent = 1.8f;

    protected abstract int GetCurrentExp();

    protected virtual void FixedUpdate()
    {
        this.Leveling();
    }

    protected virtual void Leveling()
    {
        if (this.currentLevel >= this.maxLevel) return;
        this.currentLevel = this.CalculateLevel(this.GetCurrentExp());
    }

    public int CalculateLevel(int exp)
    {
        return Mathf.FloorToInt(Mathf.Pow(exp / baseExp, 1f / exponent));
    }

    protected virtual int GetNextLevelExp()
    {
        return this.nextLevelExp = this.currentLevel * 10;
    }
}
