using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

/*
 * This script is attached to the player
 */

public class PlayerQuickSlot : MonoBehaviour
{
    private OrderedDictionary quickSlot;
    [SerializeField]
    private const int MAXCAPACITY = 4;

    private void Awake()
    {
        quickSlot = new OrderedDictionary();
    }

    /*
     * Returns an item from the Ordereddict and the amount of it
     * int index - where the item is located
     */
    public KeyValuePair<GameObject, int> GetItemAndAmount(int index)
    {
        if (quickSlot.Count - 1 >= index) //Check for out of range
        {
            KeyValuePair<GameObject, int> temp = (KeyValuePair<GameObject, int>)quickSlot[index];
            return (KeyValuePair<GameObject, int>)quickSlot[index];
        }
        return new KeyValuePair<GameObject, int>(null, 0);
    }

    /*
     * Add items into the Ordereddictionary
     * GameObject item - the item you want to add 
     * int amount - the amount of items you want added
     * Returns true if the item is successfully added
     */
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
        if (quickSlot.Count < MAXCAPACITY)
        {
            KeyValuePair<GameObject, int> itemAndAmount = new KeyValuePair<GameObject, int>(item, amount);
            quickSlot.Add(item.GetComponent<PickableItem>().itemName, itemAndAmount);
            return true;
        }
        return false;
    }

    /*
    * Remove items from the Ordereddictionary
    * string item - The name of the item you want to remove
    * int amount - the amount of items you want removed.
    * Returns true if an item is successfully removed
    */
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
