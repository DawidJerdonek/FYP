using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SaveEditHandler : MonoBehaviour
{
    //private List<TMP_InputField> inputFields = new List<TMP_InputField>();

    // Start is called before the first frame update
    void Start()
    {
        //inputFields = FindObjectsOfType<TMP_InputField>().ToList();
        //inputFields.Reverse();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveAndDestroyDialogueNodes()
    {
        Dialogue dialogue = new Dialogue();
        FindObjectOfType<DialogueEditor>().characterNameText.enabled = false;

        GameObject[] nodesOfDialogue = GameObject.FindGameObjectsWithTag("DialogueNode");
        GameObject[] nodesOfReplies = GameObject.FindGameObjectsWithTag("ReplyNode");


        //for (int i = 0; i < inputFields.Count; i++)
        //{
        //    int index = FindObjectOfType<DialogueEditor>().editableDialogues[i];
        //    dialogue = FindObjectOfType<DialogueSystemNew>().parsedDialogue[index];
        //    dialogue.dialogue = inputFields[i].text;
        //    FindObjectOfType<DialogueSystemNew>().parsedDialogue[index] = dialogue;
        //}

        for (int i = 0; i < nodesOfDialogue.Length; i++)
        {
            int index = FindObjectOfType<DialogueEditor>().editableDialogues[i];
            dialogue = FindObjectOfType<DialogueSystemNew>().parsedDialogue[index];
            dialogue.dialogue = nodesOfDialogue[i].GetComponent<TMP_InputField>().text;
            FindObjectOfType<DialogueSystemNew>().parsedDialogue[index] = dialogue;
            Destroy(nodesOfDialogue[i]);
        }

        for (int i = 0; i < nodesOfReplies.Length; i++)
        {
            int index = FindObjectOfType<DialogueEditor>().editableReplies[i];
            dialogue = FindObjectOfType<DialogueSystemNew>().parsedDialogue[index];
            dialogue.replies[i] = nodesOfReplies[i].GetComponent<TMP_InputField>().text;
            FindObjectOfType<DialogueSystemNew>().parsedDialogue[index] = dialogue;
            Destroy(nodesOfReplies[i]);
        }

        Destroy(gameObject);

       
    }
}
