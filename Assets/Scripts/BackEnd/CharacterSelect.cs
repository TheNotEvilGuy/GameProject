using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    private SaveData saveData;
    public GameObject[] character;

    private void OnEnable()
    {
        saveData = FindObjectOfType<SaveData>();
    }

    public void characterSelect(int index)
    {
        saveData.SetPlayer(character[index]);
    }
}
