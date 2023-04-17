using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButtonHandler : MonoBehaviour
{
    public GameObject dialogueNodePrefab;
    public GameObject replyNodePrefab;
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

        characterNameText.text = GetComponentInChildren<TextMeshProUGUI>().text;
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
                        dialogueNode.transform.position = new Vector3(0, 1500 - (nodeCount * 300), 0);
                        nodeCount++;

                        for(int replyCount = 0; replyCount < dialogueSystem.parsedDialogue[j].replies.Count; replyCount++)
                        {
                            TMP_InputField replyNode = Instantiate(replyNodePrefab).GetComponent<TMP_InputField>();
                            replyNode.gameObject.transform.parent = FindObjectOfType<DialogueEditor>().gameObject.transform;
                            replyNode.text = dialogueSystem.parsedDialogue[j].replies[replyCount];
                            FindObjectOfType<DialogueEditor>().editableReplies.Add(replyCount);
                            replyNode.transform.position = new Vector3(dialogueNode.transform.position.x - 150 +( (300*replyCount)), dialogueNode.transform.position.y - 100, 0);
                        }
                    }
                }
            }
        }


        FindObjectOfType<DialogueEditor>().DestroyCharacterButtons();
        
    }
}
