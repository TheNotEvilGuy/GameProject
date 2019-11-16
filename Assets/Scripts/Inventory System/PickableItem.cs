using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    private PlayerInventory playerIn;
    private MainInventory mainInventory;
    private PlayerQuickSlot playerQ;
    private QuickSlot quickSlot;

    public string itemName = "Unknown";
    public int amountToGive = 0;

    private void Start()
    {
        playerIn = FindObjectOfType<PlayerInventory>();
        mainInventory = FindObjectOfType<MainInventory>();
        playerQ = FindObjectOfType<PlayerQuickSlot>();
        quickSlot = FindObjectOfType<QuickSlot>();
    }

    //Detects when an item is "picked up" by the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && playerIn)
        { 
            GameObject copy = Instantiate(this.gameObject, new Vector3(0, 0, -15), Quaternion.identity) as GameObject;
            Destroy(copy.GetComponent<BoxCollider2D>());
            if (playerQ.Add(copy, amountToGive))
            {
                quickSlot.UpdateQuickSlot();
                Destroy(this.gameObject);
            }
            else if (playerIn.Add(copy, amountToGive))
            {
                mainInventory.UpdateInventory();
                Destroy(this.gameObject);
            }
            else
                Destroy(copy);
        }
    }
}
