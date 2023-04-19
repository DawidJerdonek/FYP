using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelEditHandler : MonoBehaviour
{

    public void DestroyDialogueNodes()
    {
        FindObjectOfType<DialogueEditor>().characterNameText.enabled = false;
        GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("DialogueNode");
        GameObject[] nodesOfReplies = GameObject.FindGameObjectsWithTag("ReplyNode");
        LineRenderer[] lineRenderers = FindObjectsOfType<LineRenderer>();

        for (int i = 0; i < toDestroy.Length; i++)
        {
            Destroy(toDestroy[i]);
        }
        for (int i = 0; i < nodesOfReplies.Length; i++)
        {
            Destroy(nodesOfReplies[i]);
        }
        for (int i = 0; i < lineRenderers.Length; i++)
        {
            Destroy(lineRenderers[i].gameObject);
        }

        FindObjectOfType<DialogueEditor>().editableDialogues.Clear();
        FindObjectOfType<DialogueEditor>().editableReplies.Clear();
        Destroy(FindObjectOfType<SaveEditHandler>().gameObject);
        Destroy(gameObject);
    }
}
