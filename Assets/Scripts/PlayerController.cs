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
    public DialogueEditor dialogueEditor;
    public TextMeshProUGUI textToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0,9.81f,0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Observer")
        {
            dialogueEditor.characterName.text = "The Observer";
            dialogueCanvas.SetActive(true);
           
        }

        if (other.tag == "MissionControl")
        {
            dialogueEditor.characterName.text = "Mission Control";
            dialogueCanvas.SetActive(true);
        }

        if (other.tag == "GreetingBot")
        {
            dialogueEditor.characterName.text = "Greeting Bot";
            dialogueEditor.greetingBotText.text = dialogueEditor.editable.text;
            textToDisplay.text = dialogueEditor.greetingBotText.text;
            dialogueCanvas.SetActive(true);
            Debug.Log("Bot");
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag == "Observer")
    //    {
    //        dialogueCanvas.enabled = true;
    //        Debug.Log("collision stay");
    //    }
    //}

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
