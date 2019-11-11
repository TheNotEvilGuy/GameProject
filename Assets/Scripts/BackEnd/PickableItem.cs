using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    private PlayerQuickSlot playerQ;
    private QuickSlot quickSlot;

    public string itemName = "Unknown";
    public int amountToGive = 0;

    private void Start()
    {
        playerQ = FindObjectOfType<PlayerQuickSlot>();
        quickSlot = FindObjectOfType<QuickSlot>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && playerQ)
        {
            GameObject copy = Instantiate(this.gameObject, new Vector3(0, 0, -15), Quaternion.identity) as GameObject;
            Destroy(copy.GetComponent<BoxCollider2D>());
            if (playerQ.Add(copy, amountToGive))
            {
                quickSlot.UpdateQuickSlot();
                Destroy(this.gameObject);
            }
            else
                Destroy(copy);
        }
    }
}
