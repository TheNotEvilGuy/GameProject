using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private static SaveData Instance;
    [SerializeField]
    private GameObject[] player;

    private void Awake()
    {
        if (Instance)
            DestroyImmediate(this); // Destroys any created copies of this object.
        else
        {
            DontDestroyOnLoad(this); // Keeps this object from scene to scene.
            Instance = this; // This object has been created.
        }
    }

    public GameObject GetPlayer()
    {
        return player[PlayerPrefs.GetInt("characterModel", 0)];
    }
}
