using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTreeShapeSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetShape()
    {
        DialogueSystemNew dialogueSystem = FindObjectOfType<DialogueSystemNew>();
        GameObject[] nodesOfDialogue = GameObject.FindGameObjectsWithTag("DialogueNode");
        GameObject[] nodesOfReplies = GameObject.FindGameObjectsWithTag("ReplyNode");

        for(int i = 0; i < nodesOfDialogue.Length; i++)
        {
            for(int j = 0; j < nodesOfReplies.Length; j++)
            {

                int stageOfDialogue = nodesOfDialogue[i].GetComponent<StageGrabber>().stageValue;
                int nextStage = nodesOfReplies[j].GetComponent<StageGrabber>().stageValue;

                //Check stages to line up in tree shape
                if (nextStage == stageOfDialogue)
                {
                    nodesOfDialogue[i].transform.position = new Vector3(nodesOfReplies[j].transform.position.x, nodesOfDialogue[i].transform.position.y, 0);
                }
            }
        }
    }
}
