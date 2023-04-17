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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowCharacterTree()
    {
        DialogueSystemNew dialogueSystem = FindObjectOfType<DialogueSystemNew>();
        List<string> identities = dialogueSystem.characterIdentity;

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
                        dialogueNode.transform.position = new Vector3(0, 1700 - (nodeCount * 100), 0);

                        nodeCount++;
                    }
                }
            }
        }
        GameObject editCancelButton = Instantiate(editCancelButtonPrefab) as GameObject;
        editCancelButton.gameObject.transform.parent = FindObjectOfType<DialogueEditor>().gameObject.transform;
        editCancelButton.transform.position = new Vector3(0, 1700 - (nodeCount * 100), 0);
        editCancelButton.GetComponent<Button>().onClick.AddListener(DestroyDialogueNodes);


        FindObjectOfType<DialogueEditor>().DestroyCharacterButtons();
        
    }

    public void DestroyDialogueNodes()
    {
        GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("DialogueNode");

        for (int i = 0; i < toDestroy.Length; i++)
        {
            Destroy(toDestroy[i]);
        }
        Destroy(this.gameObject);
    }
}
