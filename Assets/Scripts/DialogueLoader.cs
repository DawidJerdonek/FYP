using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class DialogueLoader : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public GameObject previewBackground;
    public TextMeshProUGUI previewText;

    // Start is called before the first frame update
    void Start()
    {
        previewText.enabled = false;
        previewBackground.SetActive(false);
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


    public void PreviewSaveOne()
    {
        dialogueSystem.loadedDialogueFile = dialogueSystem.readTextFile("Assets/Resources/DialogueTreeCustom1.xml");
        PopulatePreview();
        previewBackground.SetActive(true);
        previewText.enabled = true;
    }

    public void PreviewSaveTwo()
    {
        dialogueSystem.loadedDialogueFile = dialogueSystem.readTextFile("Assets/Resources/DialogueTreeCustom2.xml");
        PopulatePreview();
        previewBackground.SetActive(true);
        previewText.enabled = true;
    }

    public void PreviewSaveThree()
    {
        dialogueSystem.loadedDialogueFile = dialogueSystem.readTextFile("Assets/Resources/DialogueTreeCustom3.xml");
        PopulatePreview();
        previewBackground.SetActive(true);
        previewText.enabled = true;
    }

    public void ExitPreview()
    {
        previewBackground.SetActive(false);
        previewText.enabled = false;
    }

    private void PopulatePreview()
    {
        dialogueSystem.parser.loadData(dialogueSystem.loadedDialogueFile);
        dialogueSystem.previewedparsedDialogueFile = dialogueSystem.parser.returnDialogue();
        for (int i = 0; i < dialogueSystem.previewedparsedDialogueFile.Count; i++)
        {
            previewText.text += dialogueSystem.parsedDialogue[i].dialogue;
            previewText.text += "\n";
        }

    }
}
