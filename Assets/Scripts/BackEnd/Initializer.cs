using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    private SaveData saveData;
    private PlayerCamera playerCamera;
    private DialogueManager dialogueManager;
    private QuickSlot quickSlot;
    private GameObject player;

    private void Awake()
    {
        InitializeVariables();
        CreatePlayer();
        SetFields();
    }

    private void InitializeVariables()
    {
        saveData = FindObjectOfType<SaveData>();
        playerCamera = FindObjectOfType<PlayerCamera>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        quickSlot = FindObjectOfType<QuickSlot>();
    }

    private void CreatePlayer()
    {
        if (saveData)
            player = Instantiate(saveData.GetPlayer(), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
    }

    private void SetFields()
    {
        if (playerCamera)
            playerCamera.SetPlayer(player);
        if (dialogueManager)
            dialogueManager.SetPlayer(player);
        if (quickSlot)
            quickSlot.SetPlayer(player);
    }
}
