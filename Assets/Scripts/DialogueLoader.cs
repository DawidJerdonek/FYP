using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class DialogueLoader : MonoBehaviour
{
    private DialogueSystemNew dialogueSystem;

    // Start is called before the first frame update
    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogueSystemNew>();
    }

    public void LoadSaveDefault()
    {
        dialogueSystem.loadedDialogueFile = dialogueSystem.readTextFile("Assets/Resources/DialogueTree.xml");
        dialogueSystem.loadNewDialogue();
    }

    public void LoadSaveOne()
    {
        Debug.Log("LoadedFile");
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
