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
    public bool colliding = false;
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

    private void OnTriggerStay(Collider other)
    {
        dialogueCanvas.SetActive(true);
        currentCharacter = other.tag;
        colliding = true;
        //FindObjectOfType<DialogueSystemNew>().DialogueChoice(currentCharacter);
    }

    private void OnTriggerExit(Collider other)
    {
        dialogueCanvas.SetActive(false);
        colliding = false;
    }
}
