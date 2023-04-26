using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
//using UnityEngine.UIElements;

public class DialogueEditor : MonoBehaviour
{
    public GameObject dialogueEditor;

    public string editable;
    //public List<string> dialogueFile;

    public List<string> characterIdentity;
    public List<int> editableDialogues = new List<int>();
    public List<int> editableReplies = new List<int>();

    public Transform buttonStartPosition;

    public TMP_InputField characterNameInput;
    public TextMeshProUGUI characterNameText;

    public GameObject characterButtonPrefab;
    public GameObject dialogueNodePrefab;
    public GameObject addCharacterButton;
    public GameObject abortButton;


    private DialogueSystemNew dialogueSystem;
    // Start is called before the first frame update
    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogueSystemNew>();
        dialogueSystem.loadedDialogueFile = readTextFile("Assets/Resources/DialogueTree.xml");

        characterNameInput.gameObject.SetActive(false);
        addCharacterButton.SetActive(false);
        abortButton.SetActive(false);
        

        characterIdentity = dialogueSystem.characterIdentity;
    }

    // Update is called once per frame
    void Update()
    {
        dialogueSystem.characterIdentity = characterIdentity;
    }

    public void CreateCharacterButton()
    {
        characterNameInput.gameObject.SetActive(true);
        addCharacterButton.SetActive(true);
        abortButton.SetActive(true);
    }

    public void AddCharacter()
    {
        characterIdentity.Add(characterNameInput.text);
        Dialogue dialogue = new Dialogue();
        dialogue.character = characterNameInput.text;
        dialogue.dialogue = "";
        dialogue.stage = 0;
        dialogue.replies = new List<string>();
        dialogue.nextStage = new List<int>();
        FindObjectOfType<DialogueSystemNew>().parsedDialogue.Add(dialogue);
        //dialogueSystem.loadedDialogueFile.Add("<conversation>" + characterNameInput.text);
        //dialogueSystem.loadedDialogueFile.Add("<stage>" + 0 + "</stage>");
        //dialogueSystem.loadedDialogueFile.Add("<dialogue>");
        //dialogueSystem.loadedDialogueFile.Add("<text>" + " " + "</text>");
        //dialogueSystem.loadedDialogueFile.Add("</dialogue>");
        //dialogueSystem.loadedDialogueFile.Add("</conversation>");


        characterNameInput.text = "";
        characterNameInput.gameObject.SetActive(false);
        addCharacterButton.SetActive(false);
        abortButton.SetActive(false);

    }

    public void CancelNewCharacter()
    {
        DestroyCharacterButtons();
        characterNameInput.gameObject.SetActive(false);
        addCharacterButton.SetActive(false);
        abortButton.SetActive(false);
    }

    public void InstantiateCharacterButtons()
    {
        int j = 0;
        for (int i = 0; i < characterIdentity.Count; i++)
        {
            GameObject characterButton = Instantiate(characterButtonPrefab) as GameObject;
            characterButton.gameObject.transform.parent = gameObject.transform;
            characterButton.GetComponentInChildren<TextMeshProUGUI>().text = characterIdentity[i];


            if (i < 6)
            {
                characterButton.transform.position = new Vector3(buttonStartPosition.position.x + (j * 800), buttonStartPosition.position.y, buttonStartPosition.position.z);
            }
            else if(i >= 6 && i < 12)
            {
                characterButton.transform.position = new Vector3(buttonStartPosition.position.x + (j * 800), buttonStartPosition.position.y - 200, buttonStartPosition.position.z);
            }
            else if (i >= 12 && i < 18)
            {
                characterButton.transform.position = new Vector3(buttonStartPosition.position.x + (j * 800), buttonStartPosition.position.y - 400, buttonStartPosition.position.z);
            }
            else if (i >= 18 && i < 24)
            {
                characterButton.transform.position = new Vector3(buttonStartPosition.position.x + (j * 800), buttonStartPosition.position.y - 600, buttonStartPosition.position.z);
            }
            else if (i >= 24 && i < 30)
            {
                characterButton.transform.position = new Vector3(buttonStartPosition.position.x + (j * 800), buttonStartPosition.position.y - 800, buttonStartPosition.position.z);
            }
            else if (i >= 30 && i < 36)
            {
                characterButton.transform.position = new Vector3(buttonStartPosition.position.x + (j * 800), buttonStartPosition.position.y - 1000, buttonStartPosition.position.z);
            }

            j++;

            if (j >= 6)
            {
                j = 0;
            }

        }

    }

    public void DestroyCharacterButtons()
    {
        GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("CharacterButton");

        for(int i = 0; i < toDestroy.Length; i++ )
        {
            Destroy(toDestroy[i]);
        }
        //characterNameText.enabled = false;
    }

    List<string> readTextFile(string filePath)
    {
        int length = 0;
        List<string> lines = new List<string>();

        foreach (string line in System.IO.File.ReadLines(filePath))
        {
            lines.Add(line);
            length++;
        }

        return lines;
    }

    public void ToSaveFileOne()
    {
        dialogueSystem.parser.ReformatIntoXML();
        for (int i = 0; i < dialogueSystem.parser.reformattingList.Count; i++)
        {
            editable += dialogueSystem.parser.reformattingList[i];
            editable += "\n";
        }
        System.IO.File.WriteAllText("Assets/Resources/DialogueTreeCustom1.xml", editable);

        FindObjectOfType<DialogueLoader>().LoadSaveOne();
    }
    public void ToSaveFileTwo()
    {
        dialogueSystem.parser.ReformatIntoXML();
        for (int i = 0; i < dialogueSystem.parser.reformattingList.Count; i++)
        {
            editable += dialogueSystem.parser.reformattingList[i];
            editable += "\n";
        }
        System.IO.File.WriteAllText("Assets/Resources/DialogueTreeCustom2.xml", editable);

        FindObjectOfType<DialogueLoader>().LoadSaveTwo();
    }
    public void ToSaveFileThree()
    {
        dialogueSystem.parser.ReformatIntoXML();
        for (int i = 0; i < dialogueSystem.parser.reformattingList.Count; i++)
        {
            editable += dialogueSystem.parser.reformattingList[i];
            editable += "\n";
        }
        System.IO.File.WriteAllText("Assets/Resources/DialogueTreeCustom3.xml", editable);

        FindObjectOfType<DialogueLoader>().LoadSaveThree();
    }

}
