using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * NOTE: THIS SCRIPT IS TO BE PUT ONTO THINGS THAT HAVE DIALOGUE
 * */

public class DialogueHolder : MonoBehaviour {

	private DialogueManager dialogueManager; 
    private bool dialogueActive = false;
    private bool isTyping = false;
    private bool cancelTyping = false;
    private int currentLine = 0;

    public string[] dialogueLines;
    public float typingDelay;
    public bool soundOn = false;
    public bool loadScene = false;
    public AudioClip typingSound;
    public string sceneName;

    private void OnEnable()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();// to access the script called "Dialogue Manager"
    }

    private void Update()
    {
        if (dialogueActive == true && Input.GetKeyDown(KeyCode.Space))
        {
            if (currentLine < dialogueLines.Length - 1 && !isTyping) //Displays the next line
            {
                currentLine++;
                StartCoroutine(TextScroll(dialogueLines[currentLine]));
            }
            else if (currentLine == dialogueLines.Length - 1 && !isTyping) //Finishes displaying dialogue and hides the dialogue box and etc.
            {
                if (loadScene) 
                {
                    SceneManager.LoadScene(sceneName);
                }
                currentLine = 0;
                dialogueActive = false; 
                dialogueManager.DialogueOff();
            }
            else if (isTyping && !cancelTyping) //Skips the typing
            {
                cancelTyping = true;
            }
        }
    }

    private IEnumerator TextScroll(string lineOfText) //"Types" the dialogue lines letter by letter
    {
        int letter = 0;
        dialogueManager.dText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            if (soundOn)
                AudioSource.PlayClipAtPoint(typingSound, dialogueManager.GetPlayer().transform.position);
            dialogueManager.dText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typingDelay);
        }
        dialogueManager.dText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    private void OnTriggerStay2D (Collider2D other) {

        if (other.CompareTag("Player"))
        { // If the player and this object touch.
            if (Input.GetKeyDown(KeyCode.E))
            { // If the player presses E on this object.
                dialogueActive = true;
                dialogueManager.ShowDialogue();
                StartCoroutine(TextScroll(dialogueLines[currentLine]));
            }
        }
	}
}