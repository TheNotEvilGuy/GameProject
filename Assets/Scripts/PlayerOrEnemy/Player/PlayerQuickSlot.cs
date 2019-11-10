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
    private int slots = 0;

    private void Awake()
    {
        quickSlot = new OrderedDictionary();
        
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
            print("i.Key = " + i.Key + " and item = " + item + " AT INDEX: " + j.ToString());
            if (i.Key.GetComponent<PickableItem>().itemName == item.GetComponent<PickableItem>().itemName)
            {
                print("index " + j.ToString() + ": " + quickSlot[j]);
                quickSlot[j] = new KeyValuePair<GameObject, int>(item, i.Value + amount);
                print("index " + j.ToString() + ": " + quickSlot[j]);
                //Destroy(i.Key);
                return true;
            }
            j++;
        }
        if (slots < MAXSLOTS)
        {
            KeyValuePair<GameObject, int> itemAndAmount = new KeyValuePair<GameObject, int>(item, amount);
            quickSlot.Add(slots, itemAndAmount);
            slots++;
            return true;
        }
        return false;
    }
}
