using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButtonHandler : MonoBehaviour
{
    public GameObject dialogueNodePrefab;
    public GameObject editCancelButtonPrefab;
    public GameObject saveChangesButtonPrefab;


    private TextMeshProUGUI characterNameText;
    // Start is called before the first frame update
    void Start()
    {
        characterNameText = FindObjectOfType<DialogueEditor>().characterNameText;
        characterNameText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowCharacterTree()
    {
        DialogueSystemNew dialogueSystem = FindObjectOfType<DialogueSystemNew>();
        List<string> identities = dialogueSystem.characterIdentity;

        Debug.Log("ShowCharacterTree");
        characterNameText.text = GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log(GetComponentInChildren<TextMeshProUGUI>().text);
        characterNameText.enabled = true;

        GameObject editCancelButton = Instantiate(editCancelButtonPrefab) as GameObject;
        editCancelButton.gameObject.transform.parent = FindObjectOfType<DialogueEditor>().gameObject.transform;
        editCancelButton.transform.position = new Vector3(200, 1700 , 0);

        GameObject saveChangesButton = Instantiate(saveChangesButtonPrefab) as GameObject;
        saveChangesButton.gameObject.transform.parent = FindObjectOfType<DialogueEditor>().gameObject.transform;
        saveChangesButton.transform.position = new Vector3(-200, 1700, 0);

        //Evaluate !!!
        int nodeCount = 0;
        for (int i = 0; i < identities.Count; i++)
        {
            Debug.Log(GetComponentInChildren<TextMeshProUGUI>().text);
            if (identities[i] == GetComponentInChildren<TextMeshProUGUI>().text)
            {
                for (int j = 0; j < dialogueSystem.parsedDialogue.Count; j++)
                {
                    if (identities[i] == dialogueSystem.parsedDialogue[j].character)
                    {
                        //Display the text
                        TMP_InputField dialogueNode = Instantiate(dialogueNodePrefab).GetComponent<TMP_InputField>();
                        dialogueNode.gameObject.transform.parent = FindObjectOfType<DialogueEditor>().gameObject.transform;
                        dialogueNode.text = dialogueSystem.parsedDialogue[j].dialogue;
                        FindObjectOfType<DialogueEditor>().editableDialogues.Add(j);
                        dialogueNode.transform.position = new Vector3(0, 1500 - (nodeCount * 100), 0);
                        nodeCount++;
                    }
                }
            }
        }


        FindObjectOfType<DialogueEditor>().DestroyCharacterButtons();
        
    }
}
