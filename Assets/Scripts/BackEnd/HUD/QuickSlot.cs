using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script should be attached to an empty gameObject with children
 * containing Image components
 */

public class QuickSlot : MonoBehaviour
{
    private PlayerQuickSlot playerQ;
    private GameObject player;

    private void Start()
    {
        playerQ = player.GetComponent<PlayerQuickSlot>();
    }

    public void UpdateQuickSlot() //Updates QuickSlot UI in-game
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            KeyValuePair<GameObject, int> temp = playerQ.GetItemAndAmount(i);
            if (!temp.Key)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                break;
            }

            Transform child = transform.GetChild(i);
            child.GetComponent<Image>().sprite = temp.Key.GetComponent<SpriteRenderer>().sprite;
            child.GetChild(0).GetComponent<TextMeshProUGUI>().text = temp.Value.ToString();
            child.GetComponent<Slot>().SetItemName(temp.Key.GetComponent<PickableItem>().itemName);
            child.GetComponent<Slot>().SetAmount(temp.Value);
            child.gameObject.SetActive(true);
        }
    }

    public void Remove(int slotIndex)
    {
        Transform child = transform.GetChild(slotIndex);
        if(playerQ.Remove(child.GetComponent<Slot>().GetItemName(), 1))
            UpdateQuickSlot();
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
