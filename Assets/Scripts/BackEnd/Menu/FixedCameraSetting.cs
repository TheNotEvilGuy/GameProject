using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FixedCameraSetting : MonoBehaviour
{
    // Initializes the Fixed Camera Text to the appropriate setting
    private SaveData saveData;

    private void OnEnable()
    {
        saveData = FindObjectOfType<SaveData>();

        if (saveData)
        {
            if (saveData.fixedCamera)
                GetComponent<TextMeshProUGUI>().text = "ON";
            else
                GetComponent<TextMeshProUGUI>().text = "OFF";
        }
    }
}
