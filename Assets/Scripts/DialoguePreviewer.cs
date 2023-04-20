using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialoguePreviewer : MonoBehaviour
{
    public GameObject previewBackground;
    public GameObject returnButton;
    public TextMeshProUGUI previewText;
    private DialogueSystemNew dialogueSystem;

    private void Start()
    {
        returnButton.SetActive(false);
        previewBackground.SetActive(false);
        dialogueSystem = FindObjectOfType<DialogueSystemNew>();
    }
    public void PreviewSaveOne()
    {
        dialogueSystem.loadedDialogueFile = dialogueSystem.readTextFile("Assets/Resources/DialogueTreeCustom1.xml");
        PopulatePreview();
        previewBackground.SetActive(true);
        previewText.enabled = true;
        returnButton.SetActive(true);
    }

    public void PreviewSaveTwo()
    {
        dialogueSystem.loadedDialogueFile = dialogueSystem.readTextFile("Assets/Resources/DialogueTreeCustom2.xml");
        PopulatePreview();
        previewBackground.SetActive(true);
        previewText.enabled = true;
        returnButton.SetActive(true);
    }

    public void PreviewSaveThree()
    {
        dialogueSystem.loadedDialogueFile = dialogueSystem.readTextFile("Assets/Resources/DialogueTreeCustom3.xml");
        PopulatePreview();
        previewBackground.SetActive(true);
        previewText.enabled = true;
        returnButton.SetActive(true);
    }

    public void ExitPreview()
    {
        previewBackground.SetActive(false);
        previewText.enabled = false;
        returnButton.SetActive(false);
    }

    private void PopulatePreview()
    {
        previewText.text = "";
        dialogueSystem.previewedparsedDialogueFile.Clear();
        dialogueSystem.parser.loadData(dialogueSystem.loadedDialogueFile);
        dialogueSystem.previewedparsedDialogueFile = dialogueSystem.parser.returnDialogue();
        for (int i = 0; i < dialogueSystem.previewedparsedDialogueFile.Count; i++)
        {
            previewText.text += dialogueSystem.previewedparsedDialogueFile[i].dialogue;
            previewText.text += "\n";
        }
    }
}
