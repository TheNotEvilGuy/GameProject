using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    private SaveData saveData;
    private PlayerCamera playerCamera;
    private DialogueManager dialogueManager;
    private GameObject player;

    private void OnEnable()
    {
        saveData = FindObjectOfType<SaveData>();
        playerCamera = FindObjectOfType<PlayerCamera>();
        dialogueManager = FindObjectOfType<DialogueManager>();

        if (!saveData.GetPlayer())
        {
            player = Instantiate(saveData.defaultPlayer, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        }
        else
            player = Instantiate(saveData.GetPlayer(), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

        saveData.SetPlayer(player);
        if (playerCamera)
        {
            playerCamera.SetPlayer(player);
            playerCamera.fixedCamera = saveData.fixedCamera;
        }
        if (dialogueManager)
            dialogueManager.SetPlayer(player);
    }
}
