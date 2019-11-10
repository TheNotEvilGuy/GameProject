using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    private PlayerCamera playerCamera;

    private void OnEnable()
    {
        playerCamera = FindObjectOfType<PlayerCamera>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ActivateMenu();
        }
    }

    private void ActivateMenu()
    {
        if (menu)
        {
            bool active = false;

            for(int i = 0; i < gameObject.transform.childCount; i++)
            {
                GameObject child = gameObject.transform.GetChild(i).gameObject;
                if (child.activeSelf)
                {
                    active = true;
                    break;
                }
            }

            if (active)
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    GameObject child = gameObject.transform.GetChild(i).gameObject;
                    if (child != null)
                        child.SetActive(false);
                }
            }
            else
                menu.SetActive(true);
        }
    }

    public void LoadMenu(string name)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            if (child != null && child.name != name)
                child.SetActive(false);
            else if (child.name == name)
                child.SetActive(true);
        }
    }

    public void FixedCamera(TextMeshProUGUI myText)
    {
        if (0 != PlayerPrefs.GetInt("fixedCamera", 0))
        {
            PlayerPrefs.SetInt("fixedCamera", 0);
            if (myText)
                myText.text = "OFF";
        }
        else
        {
            PlayerPrefs.SetInt("fixedCamera", 1);
            if (myText)
                myText.text = "ON";
        }
    }
}
