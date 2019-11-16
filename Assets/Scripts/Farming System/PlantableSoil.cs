using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantableSoil : MonoBehaviour
{
    private bool playerTouching = false;
    private bool plantable = true;
    private PlayerQuickSlot quickSlot;
    private SelectQuickSlot selectQ;
    private QuickSlot quickUI;

    private void Start()
    {
        selectQ = FindObjectOfType<SelectQuickSlot>();
        quickUI = FindObjectOfType<QuickSlot>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && selectQ.GetSelected() > -1 && plantable)
        {
            KeyValuePair<GameObject, int> test = quickSlot.GetItemAndAmount(selectQ.GetSelected());
            if(test.Key && test.Key.GetComponent<Seed>())
            {
                GameObject copy = Instantiate(test.Key, transform.position, Quaternion.identity) as GameObject;
                quickSlot.Remove(test.Key.GetComponent<PickableItem>().itemName, 1);
                quickUI.UpdateQuickSlot();
                plantable = false;
                copy.GetComponent<Seed>().planted = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerTouching = true;
            quickSlot = other.GetComponent<PlayerQuickSlot>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerTouching = false;
    }
}
