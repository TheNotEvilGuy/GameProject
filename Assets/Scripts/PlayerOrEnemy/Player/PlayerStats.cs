using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private string playerName;
    private int playerReputation;

    private void Start()
    {
        playerName = PlayerPrefs.GetString("playerName", "Sai");
        playerReputation = PlayerPrefs.GetInt("playerReputation", 0);
    }

    public void SetName(string n)
    {
        playerName = n;
    }

    public void SetReputation(int r)
    {
        playerReputation = r;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetReputation()
    {
        return playerReputation;
    }
}
