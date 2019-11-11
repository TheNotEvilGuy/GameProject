using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerQuickSlot : MonoBehaviour
{
    private OrderedDictionary quickSlot;
    private const int MAXSLOTS = 9;

    private void Awake()
    {
        quickSlot = new OrderedDictionary();
        
    }

    private void Diagnose() //For debugging
    {
        print("--------------------------------");
        ICollection value = quickSlot.Values;
        int j = 0;
        foreach (KeyValuePair<GameObject, int> i in value)
        {
            print(j + ": " + i.Key);
            j++;
        }
        print(" COUNT: " + quickSlot.Count);
    }

    public KeyValuePair<GameObject, int> GetItemAndAmount(int index)
    {
        if (quickSlot.Count - 1 >= index) //Check for out of range
        {
            KeyValuePair<GameObject, int> temp = (KeyValuePair<GameObject, int>)quickSlot[index];
            return (KeyValuePair<GameObject, int>)quickSlot[index];
        }
        return new KeyValuePair<GameObject, int>(null, 0);
    }

    public bool Add(GameObject item, int amount)
    {
        ICollection value = quickSlot.Values;
        int j = 0;
        foreach (KeyValuePair<GameObject, int> i in value)
        {
            if (i.Key.GetComponent<PickableItem>().itemName == item.GetComponent<PickableItem>().itemName)
            {
                quickSlot[j] = new KeyValuePair<GameObject, int>(item, i.Value + amount);
                Destroy(i.Key);
                return true;
            }
            j++;
        }
        if (quickSlot.Count < MAXSLOTS)
        {
            KeyValuePair<GameObject, int> itemAndAmount = new KeyValuePair<GameObject, int>(item, amount);
            quickSlot.Add(item.GetComponent<PickableItem>().itemName, itemAndAmount);
            return true;
        }
        return false;
    }

    public bool Remove(string item, int amount)
    {
        ICollection value = quickSlot.Values;
        int j = 0;
        foreach (KeyValuePair<GameObject, int> i in value)
        {
            if (i.Key.GetComponent<PickableItem>().itemName == item)
            {
                if (i.Value > amount)
                    quickSlot[j] = new KeyValuePair<GameObject, int>(i.Key, i.Value - amount);
                else
                {
                    Destroy(i.Key);
                    quickSlot.RemoveAt(j);
                }
                return true;
            }
            j++;
        }
        return false;
    }
}
