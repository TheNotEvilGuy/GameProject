using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainInventory : MonoBehaviour
{
    private PlayerInventory playerI;
    private GameObject player;

    private void Start()
    {
        playerI = player.GetComponent<PlayerInventory>();
    }

    public void UpdateInventory() //Updates QuickSlot UI in-game
    {
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            KeyValuePair<GameObject, int> temp = playerI.GetItemAndAmount(i);
            if (!temp.Key)
            {
                transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
                break;
            }

            Transform child = transform.GetChild(0).GetChild(i);
            child.GetComponent<Image>().sprite = temp.Key.GetComponent<SpriteRenderer>().sprite;
            child.GetChild(0).GetComponent<TextMeshProUGUI>().text = temp.Value.ToString();
            child.GetComponent<Slot>().SetItemName(temp.Key.GetComponent<PickableItem>().itemName);
            child.GetComponent<Slot>().SetAmount(temp.Value);
            child.gameObject.SetActive(true);
        }
    }

    //Removes an item
    public void Remove(int slotIndex)
    {
        Transform child = transform.GetChild(0).GetChild(slotIndex);
        if (playerI.Remove(child.GetComponent<Slot>().GetItemName(), 1))
            UpdateInventory();
    }

    public void SetPlayer(GameObject thePlayer)
    {
        player = thePlayer;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
