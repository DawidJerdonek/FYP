using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{

    public SteamVR_Action_Vector2 input;
    private float speed = 2;
    private CharacterController characterController;

    public GameObject dialogueCanvas;
    public TextMeshProUGUI textToDisplay;

    public String currentCharacter = "";

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        dialogueCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0,9.81f,0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.tag == "Observer")
        //{
        //    //dialogueEditor.characterName.text = "The Observer";
        //    currentCharacter = "Observer";
        //    dialogueCanvas.SetActive(true);
            
        //}

        //if (other.tag == "MissionControl")
        //{
        //    //dialogueEditor.characterName.text = "Mission Control";
        //    currentCharacter = "MissionControl";
        //    //DialogueSystemNew.instance.displayText.text = DialogueSystemNew.instance.missionControlDialogue[0].dialogue;
        //    dialogueCanvas.SetActive(true);
        //}

        //if (other.tag == "GreetingBot")
        //{
        //    //dialogueEditor.characterName.text = "Greeting Bot";
        //    currentCharacter = "GreetingBot";
        //    //DialogueSystemNew.instance.displayText.text = DialogueSystemNew.instance.greetingBotDialogue[0].dialogue;
        //   // textToDisplay.text = dialogueEditor.greetingBotText.text;
        //    dialogueCanvas.SetActive(true);
        //}

        currentCharacter = other.tag;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Observer")
        {
            dialogueCanvas.SetActive(false);
        }
        if (other.tag == "MissionControl")
        {
            dialogueCanvas.SetActive(false);
        }
        if (other.tag == "GreetingBot")
        {
            dialogueCanvas.SetActive(false);
        }
    }
}
