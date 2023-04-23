using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class DialogueTreeShapeSetter : MonoBehaviour
{
    public LineRenderer lineRendererPrefab;

    public void SetShape()
    {
        DialogueSystemNew dialogueSystem = FindObjectOfType<DialogueSystemNew>();
        GameObject[] nodesOfDialogue = GameObject.FindGameObjectsWithTag("DialogueNode");
        GameObject[] nodesOfReplies = GameObject.FindGameObjectsWithTag("ReplyNode");
        LineRenderer[] lineRenderers = FindObjectsOfType<LineRenderer>();

        //for (int i = 0; i < lineRenderers.Length; i++)
        //{
        //    Destroy(lineRenderers[i]);
        //}

        for (int i = 0; i < nodesOfDialogue.Length; i++)
        {
            for(int j = 0; j < nodesOfReplies.Length; j++)
            {

                int stageOfDialogue = nodesOfDialogue[i].GetComponent<StageGrabber>().stageValue;
                int nextStage = nodesOfReplies[j].GetComponent<StageGrabber>().stageValue;

                //Check stages to line up in tree shape
                if (nextStage == stageOfDialogue)
                {
                    nodesOfDialogue[i].transform.position = new Vector3(nodesOfReplies[j].transform.position.x, nodesOfReplies[j].transform.position.y - 200, 0);
                    //Set Replies lines to next Nodes
                    LineRenderer line = Instantiate(lineRendererPrefab);
                    line.positionCount = 2;
                    line.SetPosition(0, nodesOfReplies[j].transform.position);
                    line.SetPosition(1, nodesOfDialogue[i].transform.position);
                    line.GetComponent<LineInformation>().startObject = nodesOfReplies[j].gameObject;
                    line.GetComponent<LineInformation>().endObject = nodesOfDialogue[i].gameObject;
                }
            }
        }
    }


}
