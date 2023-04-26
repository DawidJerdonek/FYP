using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SaveEditHandler : MonoBehaviour
{

    public void SaveAndDestroyDialogueNodes()
    {
        Dialogue dialogue = new Dialogue();

        //Collect all nodes and lines
        FindObjectOfType<DialogueEditor>().characterNameText.enabled = false;
        GameObject[] nodesOfDialogue = GameObject.FindGameObjectsWithTag("DialogueNode");
        GameObject[] nodesOfReplies = GameObject.FindGameObjectsWithTag("ReplyNode");
        LineRenderer[] lineRenderers = FindObjectsOfType<LineRenderer>();

        for (int i = 0; i < nodesOfDialogue.Length; i++)
        {
            int index = FindObjectOfType<DialogueEditor>().editableDialogues[i];
            dialogue = FindObjectOfType<DialogueSystemNew>().parsedDialogue[index];
            dialogue.dialogue = nodesOfDialogue[i].GetComponent<TMP_InputField>().text; //Update all dialogue nodes

            for (int j = 0; j < dialogue.replies.Count; j++)
            {
                for(int reply = 0; reply < nodesOfReplies.Length; reply++)
                {
                    if (dialogue.nextStage[j] == nodesOfReplies[reply].GetComponent<StageGrabber>().stageValue)
                    {
                        dialogue.replies[j] = nodesOfReplies[reply].GetComponent<TMP_InputField>().text; //Update all reply nodes
                    }
                    Destroy(nodesOfReplies[reply]); //Destroy all reply nodes
                }
            }

            FindObjectOfType<DialogueSystemNew>().parsedDialogue[index] = dialogue;
            Destroy(nodesOfDialogue[i]); //Destroy all dialogue nodes
            
        }

        for (int i = 0; i < lineRenderers.Length; i++)
        {
            Destroy(lineRenderers[i].gameObject); //Destroy all lines
        }

        FindObjectOfType<DialogueEditor>().editableDialogues.Clear();
        FindObjectOfType<DialogueEditor>().editableReplies.Clear();
        Destroy(FindObjectOfType<CancelEditHandler>().gameObject);
        Destroy(gameObject);
    }
}
