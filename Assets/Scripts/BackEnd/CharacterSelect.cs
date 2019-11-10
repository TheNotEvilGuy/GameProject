using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    private SaveData saveData;
   
    private void OnEnable()
    {
        saveData = FindObjectOfType<SaveData>();
    }

    public void characterSelect(int index)
    {
        PlayerPrefs.SetInt("characterModel", index);
    }
}
