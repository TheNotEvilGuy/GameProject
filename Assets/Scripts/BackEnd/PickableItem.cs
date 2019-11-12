using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    private PlayerInventory playerQ;
    private MainInventory mainInventory;

    public string itemName = "Unknown";
    public int amountToGive = 0;

    private void Start()
    {
        playerQ = FindObjectOfType<PlayerInventory>();
        mainInventory = FindObjectOfType<MainInventory>();
    }

    //Detects when an item is "picked up" by the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && playerQ)
        {
            GameObject copy = Instantiate(this.gameObject, new Vector3(0, 0, -15), Quaternion.identity) as GameObject;
            Destroy(copy.GetComponent<BoxCollider2D>());
            if (playerQ.Add(copy, amountToGive))
            {
                mainInventory.UpdateInventory();
                Destroy(this.gameObject);
            }
            else
                Destroy(copy);
        }
    }
}
