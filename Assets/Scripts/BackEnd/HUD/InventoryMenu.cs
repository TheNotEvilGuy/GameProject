using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuBackground;
    [SerializeField]
    private GameObject inventoryMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            ActivateMenu();
    }

    private void ActivateMenu()
    {
        if (inventoryMenuBackground)
        {
            if (inventoryMenuBackground.activeSelf)
            {
                inventoryMenuBackground.SetActive(false);
                inventoryMenu.SetActive(false);
            }
            else
            {
                inventoryMenuBackground.SetActive(true);
                inventoryMenu.SetActive(true);
            }
        }
    }
}
