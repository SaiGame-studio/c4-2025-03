using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    int currentHp = 10;
    int maxHp = 1000000;
    public float weight = 1f;
    string enemyName = "";

    private void Awake()
    {
        this.RandomWeight();
    }

    bool IsDead()
    {
        if (this.currentHp > 0) return false;
        else return true;
    }

    bool IsAlive()
    {
        return this.currentHp > 0;
    }

    int GetCurrenHp()
    {
        return this.currentHp;
    }

    void RandomWeight()
    {
        this.weight = UnityEngine.Random.Range(0.5f, 4f);
    }
}
