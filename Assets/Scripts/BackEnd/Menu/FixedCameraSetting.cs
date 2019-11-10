using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FixedCameraSetting : MonoBehaviour
{
    // Initializes the Fixed Camera Text to the appropriate setting

    private void Awake()
    {
        if (0 != PlayerPrefs.GetInt("fixedCamera", 0))
            GetComponent<TextMeshProUGUI>().text = "ON";
        else
            GetComponent<TextMeshProUGUI>().text = "OFF";  
    }
}
