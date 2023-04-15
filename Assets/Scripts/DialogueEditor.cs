using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class DialogueEditor : MonoBehaviour
{
    public GameObject dialogueEditor;

    public TMP_InputField editable;
    //public TextMeshProUGUI characterName;
    //public List<string> dialogueFile;

    public List<string> characterIdentity;

    public Transform buttonStartPosition;

    public TMP_InputField characterNameInput;

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

        dialogueSystem.loadedDialogueFile.Add("<conversation>" + characterNameInput.text);
        for (int i = 0; i < dialogueSystem.loadedDialogueFile.Count; i++)
        {
            Debug.Log(dialogueSystem.loadedDialogueFile[i]);
        }


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

            //characterButton.GetComponent<Button>().onClick.AddListener(showCharacterTree);
            // Button button = characterButton.gameObject.GetComponent<Button>();
            // button.onClick.AddListener(showCharacterTree);


            if (i < 6)
            {
                characterButton.transform.position = new Vector3(buttonStartPosition.position.x + (j * 500), buttonStartPosition.position.y, buttonStartPosition.position.z);
            }
            else if(i >= 6 && i < 12)
            {
                characterButton.transform.position = new Vector3(buttonStartPosition.position.x + (j * 500), buttonStartPosition.position.y - 100, buttonStartPosition.position.z);
            }
            else if (i >= 12 && i < 18)
            {
                characterButton.transform.position = new Vector3(buttonStartPosition.position.x + (j * 500), buttonStartPosition.position.y - 200, buttonStartPosition.position.z);
            }
            else if (i >= 18 && i < 24)
            {
                characterButton.transform.position = new Vector3(buttonStartPosition.position.x + (j * 500), buttonStartPosition.position.y - 300, buttonStartPosition.position.z);
            }
            else if (i >= 24 && i < 30)
            {
                characterButton.transform.position = new Vector3(buttonStartPosition.position.x + (j * 500), buttonStartPosition.position.y - 400, buttonStartPosition.position.z);
            }
            else if (i >= 30 && i < 36)
            {
                characterButton.transform.position = new Vector3(buttonStartPosition.position.x + (j * 500), buttonStartPosition.position.y - 500, buttonStartPosition.position.z);
            }

            j++;

            if (j >= 6)
            {
                j = 0;
            }

        }

    }

    public void showCharacterTree()
    {
        //Evaluate !!!
        int nodeCount = 0;
        for (int i = 0; i < GetComponent<DialogueEditor>().characterIdentity.Count; i++)
        {
            if (characterIdentity[i] == GetComponentInChildren<TextMeshProUGUI>().text)
            {
                for (int j = 0; j < dialogueSystem.parsedDialogue.Count; j++)
                {
                    if (characterIdentity[i] == dialogueSystem.parsedDialogue[j].character)
                    {
                        //Display the text
                        GameObject dialogueNode = Instantiate(dialogueNodePrefab) as GameObject;
                        dialogueNode.gameObject.transform.parent = gameObject.transform;
                        dialogueNode.GetComponentInChildren<TextMeshProUGUI>().text = dialogueSystem.parsedDialogue[j].dialogue;
                        dialogueNode.transform.position = new Vector3(0 , 800 * nodeCount, 0);

                        nodeCount++;
                    }
                }
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
        for (int i = 0; i < dialogueSystem.loadedDialogueFile.Count; i++)
        {
            editable.text += dialogueSystem.loadedDialogueFile[i];
            editable.text += "\n";
        }
        System.IO.File.WriteAllText("Assets/Resources/DialogueTreeCustom1.xml", editable.text);

        FindObjectOfType<DialogueLoader>().LoadSaveOne();
    }
    public void ToSaveFileTwo()
    {
        for (int i = 0; i < dialogueSystem.loadedDialogueFile.Count; i++)
        {
            editable.text += dialogueSystem.loadedDialogueFile[i];
            editable.text += "\n";
        }
        System.IO.File.WriteAllText("Assets/Resources/DialogueTreeCustom2.xml", editable.text);

        FindObjectOfType<DialogueLoader>().LoadSaveTwo();
    }
    public void ToSaveFileThree()
    {
        for (int i = 0; i < dialogueSystem.loadedDialogueFile.Count; i++)
        {
            editable.text += dialogueSystem.loadedDialogueFile[i];
            editable.text += "\n";
        }
        System.IO.File.WriteAllText("Assets/Resources/DialogueTreeCustom3.xml", editable.text);

        FindObjectOfType<DialogueLoader>().LoadSaveThree();
    }
}
