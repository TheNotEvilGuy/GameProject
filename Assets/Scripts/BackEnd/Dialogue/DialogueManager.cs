using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private SaveData saveData;
    private GameObject player;

	public GameObject dBox;
	public Text dText;
    //public string levelToLoad;
    //public int firstStep, secondStep, thirdStep;
    //public Text[] optionText;
    //public GameObject[] options;
    //public string[] optionDialogue;

    public void DialogueOff()
    {
        // When dialogue ends, all dialogue boxes are hidden and all other variables go back to normal.

        //options [0].SetActive (false);
        //options [1].SetActive (false);
        //options [2].SetActive (false);
        dBox.SetActive(false);
        player.GetComponent<PlayerMovement>().canMove = true;
    }

	public void ShowDialogue() { // Shows dialogue and stops player from moving
		dBox.SetActive (true);
        player.GetComponent<PlayerMovement>().canMove = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    public void SetPlayer(GameObject thePlayer)
    {
        player = thePlayer;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
    /*
	void Update () {
		if (saveData.currentline <= saveData.dialoguelines.Length) {
            //dText.text = saveData.dialoguelines [saveData.currentline];  // shows current line of text.
            StartCoroutine(TextScroll(saveData.dialoguelines[saveData.currentline]));
        }
        
		if (saveData.currentline == saveData.dialoglines.Length - 1 && saveData.option) {
			Choices (); // if the object has options, Choices will run.
		}
        
		if (saveData.dialogueActive && Input.GetKeyDown (KeyCode.Space) && !saveData.option) {

			saveData.currentline++; // goes to the next line of text
			
		}

        else if (saveData.currentline == saveData.dialoguelines.Length)
        { // When dialogue ends, all dialogue boxes are hidden and all other variables go back to normal.

            dBox.SetActive(false);
            //options [0].SetActive (false);
            //options [1].SetActive (false);
            //options [2].SetActive (false);
            saveData.currentline = 0;
            player.GetComponent<PlayerMovement>().canMove = true;
        }
    }
    
    public void Choices(){
		if (saveData.section) { // When the player goes to the conference door.
			options[0].SetActive(true);
			options[1].SetActive(true);
			optionText [0].text = optionDialogue [0];
			optionText [1].text = optionDialogue [1];
			if (Input.GetKeyDown (KeyCode.Alpha1) && saveData.bayCar) { // If the player presses 1 and are at the car, they will go to Bay Section.
				saveData.currentline++;
				saveData.bay = true;
				saveData.state = false;
				saveData.national = false;
				saveData.section = false;
			}
			if (Input.GetKeyDown (KeyCode.Alpha1) && saveData.stateBus) { // If the player presses 1 and are at the bus, they will go to State Section.
				saveData.currentline++;
				saveData.bay = false;
				saveData.state = true;
				saveData.national = false;
			}
			if (Input.GetKeyDown (KeyCode.Alpha1) && saveData.nationalsPlane) { // If the player presses 1 and are at the plane, they will go to Nationals.
				saveData.currentline++;
				saveData.bay = false;
				saveData.state = false;
				saveData.national = true;
			}
			if (Input.GetKeyDown(KeyCode.Alpha2)) { // If the player presses 2, they do nothing.
				saveData.currentline++;
				saveData.nationalsPlane = false;
				saveData.stateBus = false;
				saveData.bayCar = false;
			}
		}
	}
    */
}