using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Work in progress
 */

public class PlayerInventory : MonoBehaviour
{
    private Hashtable inventory;

    private void Awake()
    {
        inventory = new Hashtable();
    }
}
