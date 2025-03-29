using UnityEngine;

public class PlayerInfo : SaiBehavior
{
    //Data type, variable, data (value)
    //Operator: = + - * /
    int currentHp = 10;
    int maxHp = 1000000;
    float weight = 1.5f;
    string name = "Sai Game";

    bool IsDead()
    {
        if(this.currentHp > 0) return false;
        else return true;
    }

    bool IsAlive()
    {
        return this.currentHp > 0;
    }
}
