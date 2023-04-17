using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class DialogueLoader : MonoBehaviour
{
   // public GameObject previewBackground;
    //public GameObject returnButton;
    //Move commented content to Dialogue Previewer if necessary
    //public TextMeshProUGUI previewText;

    private DialogueSystemNew dialogueSystem;
    // Start is called before the first frame update
    void Start()
    {
        //returnButton.SetActive(false);
        //previewBackground.SetActive(false);
        dialogueSystem = FindObjectOfType<DialogueSystemNew>();
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


    //public void PreviewSaveOne()
    //{
    //    dialogueSystem.loadedDialogueFile = dialogueSystem.readTextFile("Assets/Resources/DialogueTreeCustom1.xml");
    //    PopulatePreview();
    //    previewBackground.SetActive(true);
    //    previewText.enabled = true;
    //    returnButton.SetActive(true);
    //}

    //public void PreviewSaveTwo()
    //{
    //    dialogueSystem.loadedDialogueFile = dialogueSystem.readTextFile("Assets/Resources/DialogueTreeCustom2.xml");
    //    PopulatePreview();
    //    previewBackground.SetActive(true);
    //    previewText.enabled = true;
    //    returnButton.SetActive(true);
    //}

    //public void PreviewSaveThree()
    //{
    //    dialogueSystem.loadedDialogueFile = dialogueSystem.readTextFile("Assets/Resources/DialogueTreeCustom3.xml");
    //    PopulatePreview();
    //    previewBackground.SetActive(true);
    //    previewText.enabled = true;
    //    returnButton.SetActive(true);
    //}

    //public void ExitPreview()
    //{
    //    previewBackground.SetActive(false);
    //    previewText.enabled = false;
    //    returnButton.SetActive(false);
    //}

    //private void PopulatePreview()
    //{
    //    previewText.text = "";
    //    dialogueSystem.previewedparsedDialogueFile.Clear();
    //    dialogueSystem.parser.loadData(dialogueSystem.loadedDialogueFile);
    //    dialogueSystem.previewedparsedDialogueFile = dialogueSystem.parser.returnDialogue();
    //    for (int i = 0; i < dialogueSystem.previewedparsedDialogueFile.Count; i++)
    //    {
    //        previewText.text += dialogueSystem.previewedparsedDialogueFile[i].dialogue;
    //        previewText.text += "\n";
    //    }

    //}
}
