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

    private void LateUpdate()
    {
        if (playerQ)
            UpdateQuickSlot();
    }

    private void UpdateQuickSlot()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            KeyValuePair<GameObject, int> temp = playerQ.GetItemAndAmount(i);
            if (!temp.Key)
                break;

            transform.GetChild(i).GetComponent<Image>().sprite = temp.Key.GetComponent<SpriteRenderer>().sprite;
            transform.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = temp.Value.ToString();
            transform.GetChild(i).gameObject.SetActive(true);
        }
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
