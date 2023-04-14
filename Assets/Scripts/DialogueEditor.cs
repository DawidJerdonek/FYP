using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DialogueEditor : MonoBehaviour
{
    public GameObject dialogueEditor;

    public TMP_InputField editable;
    //public TextMeshProUGUI characterName;
    public List<string> dialogueFile;

    public List<string> characterIdentity;

    public Transform buttonStartPosition;
    public GameObject characterButtonPrefab;

    public TMP_InputField characterNameInput;
    public GameObject addCharacterButton;
    public GameObject abortButton;

    // Start is called before the first frame update
    void Start()
    {
        dialogueFile = readTextFile("Assets/Resources/DialogueTree.xml");
        for (int i = 0; i < dialogueFile.Count; i++)
        {
            editable.text += dialogueFile[i];
            editable.text += "\n";
        }

        characterNameInput.gameObject.SetActive(false);
        addCharacterButton.SetActive(false);
        abortButton.SetActive(false);

        characterIdentity = FindObjectOfType<DialogueSystemNew>().characterIdentity;


    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<DialogueSystemNew>().characterIdentity = characterIdentity;
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
        //FindObjectOfType<DialogueSystemNew>().loadedDialogueFile
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
        System.IO.File.WriteAllText("Assets/Resources/DialogueTreeCustom1.xml", editable.text);
    }
    public void ToSaveFileTwo()
    {
        System.IO.File.WriteAllText("Assets/Resources/DialogueTreeCustom2.xml", editable.text);
    }
    public void ToSaveFileThree()
    {
        System.IO.File.WriteAllText("Assets/Resources/DialogueTreeCustom3.xml", editable.text);
    }
}
