using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is attached to each "slots" in the UI
 */

public class Slot : MonoBehaviour
{
    private string itemName = "Unknown";
    private int amount = 0;

    public void SetItemName(string name)
    {
        itemName = name;
    }

    public void SetAmount(int a)
    {
        amount = a;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public int GetAmount()
    {
        return amount;
    }
}
