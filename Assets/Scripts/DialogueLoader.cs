using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLoader : MonoBehaviour
{
    public DialogueSystem dialogueSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSaveDefault()
    {
        dialogueSystem.loadedDialogueFile = dialogueSystem.readTextFile("Assets/Resources/DialogueTree.xml");
        dialogueSystem.loadNewDialogue();
    }

    public void LoadSaveOne()
    {
        dialogueSystem.loadedDialogueFile = dialogueSystem.readTextFile("Assets/Resources/DialogueTreeCustom1.xml");
        dialogueSystem.loadNewDialogue();
    }

    public void LoadSaveTwo()
    {
        dialogueSystem.loadedDialogueFile = dialogueSystem.readTextFile("Assets/Resources/DialogueTreeCustom2.xml");
        dialogueSystem.loadNewDialogue();
    }

    public void LoadSaveThree()
    {
        dialogueSystem.loadedDialogueFile = dialogueSystem.readTextFile("Assets/Resources/DialogueTreeCustom3.xml");
        dialogueSystem.loadNewDialogue();
    }
}
