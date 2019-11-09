using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private static SaveData Instance;
    private GameObject player;

    public GameObject defaultPlayer;

    //Game Settings
    [HideInInspector]
    public bool fixedCamera = false;

    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(this); // Destroys any created copies of this object.
        }
        else
        {
            DontDestroyOnLoad(this); // Keeps this object from scene to scene.
            Instance = this; // This object has been created.
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
