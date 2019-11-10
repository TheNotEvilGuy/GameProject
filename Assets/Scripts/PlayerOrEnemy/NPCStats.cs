using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStats : MonoBehaviour
{
    private string name = "Yerv";
    private int reputation = 0;

    public void SetName(string n)
    {
        name = n;
    }

    public void SetReputation(int r)
    {
        reputation = r;
    }

    public string GetName()
    {
        return name;
    }

    public int GetReputation()
    {
        return reputation;
    }
}
