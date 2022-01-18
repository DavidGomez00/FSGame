using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int highScore;
    public int currency;
    public int[] idsAdquired;

    public PlayerData(int highScore, int currency, int[] idsAdquired)
    {
        this.highScore = highScore;
        this.currency = currency;
        this.idsAdquired = idsAdquired;
    }
}
