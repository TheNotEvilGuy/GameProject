using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectQuickSlot : MonoBehaviour
{
    private GameObject slot;
    private int selected = -1;
    private Color def = new Color (1, 1, 1);
    private Color highlight = new Color(0.5707f, 1f, 0.7532f);
    private void Update()
    {
        Select();
    }

    private void Select()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            try
            {
                slot = transform.GetChild(0).gameObject;
                if (slot.GetComponent<Image>().color == def)
                {
                    slot.GetComponent<Image>().color = highlight;
                    if (selected > -1)
                        transform.GetChild(selected).GetComponent<Image>().color = def;
                    selected = 0;
                }
                else
                {
                    slot.GetComponent<Image>().color = def;
                    selected = -1;
                }
            }
            catch { }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            try
            {
                slot = transform.GetChild(1).gameObject;
                if (slot.GetComponent<Image>().color == def)
                {
                    slot.GetComponent<Image>().color = highlight;
                    if (selected > -1)
                        transform.GetChild(selected).GetComponent<Image>().color = def;
                    selected = 1;
                }
                else
                {
                    slot.GetComponent<Image>().color = def;
                    selected = -1;
                }
            }
            catch { }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            try
            {
                slot = transform.GetChild(2).gameObject;
                if (slot.GetComponent<Image>().color == def)
                {
                    slot.GetComponent<Image>().color = highlight;
                    if (selected > -1)
                        transform.GetChild(selected).GetComponent<Image>().color = def;
                    selected = 2;
                }
                else
                {
                    slot.GetComponent<Image>().color = def;
                    selected = -1;
                }
            }
            catch { }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            try
            {
                slot = transform.GetChild(3).gameObject;
                if (slot.GetComponent<Image>().color == def)
                {
                    slot.GetComponent<Image>().color = highlight;
                    if (selected > -1)
                        transform.GetChild(selected).GetComponent<Image>().color = def;
                    selected = 3;
                }
                else
                {
                    slot.GetComponent<Image>().color = def;
                    selected = -1;
                }
            }
            catch { }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            try
            {
                slot = transform.GetChild(4).gameObject;
                if (slot.GetComponent<Image>().color == def)
                {
                    slot.GetComponent<Image>().color = highlight;
                    if (selected > -1)
                        transform.GetChild(selected).GetComponent<Image>().color = def;
                    selected = 4;
                }
                else
                {
                    slot.GetComponent<Image>().color = def;
                    selected = -1;
                }
            }
            catch { }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            try
            {
                slot = transform.GetChild(5).gameObject;
                if (slot.GetComponent<Image>().color == def)
                {
                    slot.GetComponent<Image>().color = highlight;
                    if (selected > -1)
                        transform.GetChild(selected).GetComponent<Image>().color = def;
                    selected = 5;
                }
                else
                {
                    slot.GetComponent<Image>().color = def;
                    selected = -1;
                }
            }
            catch { }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
        {
            try
            {
                slot = transform.GetChild(6).gameObject;
                if (slot.GetComponent<Image>().color == def)
                {
                    slot.GetComponent<Image>().color = highlight;
                    if (selected > -1)
                        transform.GetChild(selected).GetComponent<Image>().color = def;
                    selected = 6;
                }
                else
                {
                    slot.GetComponent<Image>().color = def;
                    selected = -1;
                }
            }
            catch { }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
        {
            try
            {
                slot = transform.GetChild(7).gameObject;
                if (slot.GetComponent<Image>().color == def)
                {
                    slot.GetComponent<Image>().color = highlight;
                    if (selected > -1)
                        transform.GetChild(selected).GetComponent<Image>().color = def;
                    selected = 7;
                }
                else
                {
                    slot.GetComponent<Image>().color = def;
                    selected = -1;
                }
            }
            catch { }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            try
            {
                slot = transform.GetChild(8).gameObject;
                if (slot.GetComponent<Image>().color == def)
                {
                    slot.GetComponent<Image>().color = highlight;
                    if (selected > -1)
                        transform.GetChild(selected).GetComponent<Image>().color = def;
                    selected = 8;
                }
                else
                {
                    slot.GetComponent<Image>().color = def;
                    selected = -1;
                }
            }
            catch { }
        }
    }

    public int GetSelected()
    {
        return selected;
    }
}
