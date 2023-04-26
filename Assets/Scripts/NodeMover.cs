using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeMover : MonoBehaviour
{
    private Camera camera;
    private float cameraDistanceZ;
    private int stage;
    private List<Dialogue> parsedDialogue;

    public GameObject deleteButton;
    public GameObject addButton;
    private TextMeshProUGUI characterText;

    public GameObject dialogueNodePrefab;
    public GameObject replyNodePrefab;
    public LineRenderer lineRendererPrefab;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        cameraDistanceZ = camera.WorldToScreenPoint(transform.position).z;
        stage = GetComponentInParent<StageGrabber>().stageValue;
        //deleteButton.SetActive(false);
        //addButton.SetActive(false);
        characterText  = GameObject.FindGameObjectWithTag("NameDisplay").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        parsedDialogue = FindObjectOfType<DialogueSystemNew>().parsedDialogue;
        cameraDistanceZ = camera.WorldToScreenPoint(transform.position).z;
        //for (int i = 0; i < parsedDialogue.Count; i++)
        //{
        //    if (parsedDialogue[i].replies.Count == 0)
        //    {
        //        if (parsedDialogue[i].character == characterText.text)
        //        {
                
        //            deleteButton.SetActive(true);
        //            addButton.SetActive(true);
        //        }
        //    }
        //    else
        //    {
        //        deleteButton.SetActive(false);
        //        addButton.SetActive(false);
        //    }
        //}
    }

    private void OnMouseDrag()
    {
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDistanceZ);
        Vector3 worldPos = camera.ScreenToWorldPoint(screenPos);
        transform.position = worldPos;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void DeleteNode()
    {
        characterText = GameObject.FindGameObjectWithTag("NameDisplay").GetComponent<TextMeshProUGUI>();

        for (int i = 0; i< parsedDialogue.Count; i++)
        {
            if (parsedDialogue[i].character == characterText.text)
            {
                if (gameObject.tag == "DialogueNode")
                {
                    if (parsedDialogue[i].stage == stage)
                    {
                        parsedDialogue.RemoveAt(i);
                        Destroy(gameObject);
                    }
                }
                else if (gameObject.tag == "ReplyNode")
                {
                    for(int j = 0; j < parsedDialogue[i].nextStage.Count; j++)
                    {
                        if (parsedDialogue[i].nextStage[j] == stage)
                        {
                            parsedDialogue[i].replies.RemoveAt(j);
                            parsedDialogue[i].nextStage.RemoveAt(j);
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }

    public void AddNode()
    {
        //IF on dialogue node, create reply
        if (gameObject.tag == "DialogueNode")
        {
            //Spawn in all reply nodes
            Dialogue dialogue = new Dialogue();
            for (int i = 0; i < parsedDialogue.Count; i++)
            {
                if (parsedDialogue[i].character == characterText.text)
                {
                    if (parsedDialogue[i].stage == gameObject.GetComponent<StageGrabber>().stageValue)
                    {
                        dialogue = parsedDialogue[i];
                    }
                }
            }

            TMP_InputField replyNode = Instantiate(replyNodePrefab).GetComponent<TMP_InputField>();
            replyNode.gameObject.transform.parent = FindObjectOfType<DialogueEditor>().gameObject.transform;
            dialogue.replies.Add(replyNode.text);
            int nextStageNumber = 0;
            for(int i = 0; i < parsedDialogue.Count; i++)
            {
                for(int j = 0; j < parsedDialogue[i].nextStage.Count; j++)
                {
                    if (nextStageNumber < parsedDialogue[i].nextStage[j])
                    {
                        nextStageNumber = parsedDialogue[i].nextStage[j];
                    }
                }

            }
            nextStageNumber++;
            dialogue.nextStage.Add(nextStageNumber);

            replyNode.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 300, 0);
            replyNode.GetComponentInChildren<TextMeshProUGUI>().text = "Next Stage: " + nextStageNumber;
            replyNode.GetComponent<StageGrabber>().stageValue = nextStageNumber;

            LineRenderer line = Instantiate(lineRendererPrefab);
            line.positionCount = 2;
            line.SetPosition(0, replyNode.transform.position);
            line.SetPosition(1, gameObject.transform.position);
            line.GetComponent<LineInformation>().startObject = replyNode.gameObject;
            line.GetComponent<LineInformation>().endObject = gameObject;

            //if (identities[i] == dialogueSystem.parsedDialogue[j].character)
            //{
            //    //Spawn in all dialogue nodes
            //    TMP_InputField dialogueNode = Instantiate(dialogueNodePrefab).GetComponent<TMP_InputField>();
            //    dialogueNode.gameObject.transform.parent = FindObjectOfType<DialogueEditor>().gameObject.transform;
            //    dialogueNode.text = dialogueSystem.parsedDialogue[j].dialogue;
            //    FindObjectOfType<DialogueEditor>().editableDialogues.Add(j);
            //    dialogueNode.transform.position = new Vector3(0, 1500 - (nodeCount * 300), 0);
            //    dialogueNode.GetComponentInChildren<TextMeshProUGUI>().text
            //        = "Stage: " + dialogueSystem.parsedDialogue[j].stage.ToString();

            //    dialogueNode.GetComponent<StageGrabber>().stageValue = dialogueSystem.parsedDialogue[j].stage;
            //    FindObjectOfType<DialogueTreeShapeSetter>().SetShape();
            //    nodeCount++;

            //    //Spawn in all reply nodes
            //    for (int replyCount = 0; replyCount < dialogueSystem.parsedDialogue[j].replies.Count; replyCount++)
            //    {
            //        LineRenderer line = Instantiate(lineRendererPrefab);
            //        TMP_InputField replyNode = Instantiate(replyNodePrefab).GetComponent<TMP_InputField>();
            //        replyNode.gameObject.transform.parent = FindObjectOfType<DialogueEditor>().gameObject.transform;
            //        replyNode.text = dialogueSystem.parsedDialogue[j].replies[replyCount];
            //        FindObjectOfType<DialogueEditor>().editableReplies.Add(j);
            //        if (nodeCount == 1)
            //        {
            //            replyNode.transform.position = new Vector3(dialogueNode.transform.position.x - 600 + ((1200 * replyCount)), dialogueNode.transform.position.y - 100, 0);
            //            //Set DialogueNodes lines to Replies
            //            line.positionCount = 2;
            //            line.SetPosition(0, replyNode.transform.position);
            //            line.SetPosition(1, dialogueNode.transform.position);
            //            line.GetComponent<LineInformation>().startObject = replyNode.gameObject;
            //            line.GetComponent<LineInformation>().endObject = dialogueNode.gameObject;
            //        }
            //        else
            //        {
            //            replyNode.transform.position = new Vector3(dialogueNode.transform.position.x - 300 + ((600 * replyCount)), dialogueNode.transform.position.y - 100, 0);
            //            //Set DialogueNodes lines to Replies
            //            line.positionCount = 2;
            //            line.SetPosition(0, replyNode.transform.position);
            //            line.SetPosition(1, dialogueNode.transform.position);
            //            line.GetComponent<LineInformation>().startObject = replyNode.gameObject;
            //            line.GetComponent<LineInformation>().endObject = dialogueNode.gameObject;
            //        }
            //        replyNode.GetComponentInChildren<TextMeshProUGUI>().text
            //            = "Next Stage: " + dialogueSystem.parsedDialogue[j].nextStage[replyCount].ToString();

            //        replyNode.GetComponent<StageGrabber>().stageValue = dialogueSystem.parsedDialogue[j].nextStage[replyCount];

            //    }
            //}

        }
        else if (gameObject.tag == "ReplyNode") //If on reply node create dialogue node
        {
            GameObject[] checkForPath =  GameObject.FindGameObjectsWithTag("DialogueNode");
            bool pathExists = false;
            for(int i = 0; i < checkForPath.Length; i++)
            {
                if (checkForPath[i].GetComponent<StageGrabber>().stageValue == gameObject.GetComponent<StageGrabber>().stageValue)
                {
                    pathExists = true;
                }
            }

            if (pathExists == false)
            {
                Dialogue dialogue = new Dialogue();
                TMP_InputField dialogueNode = Instantiate(dialogueNodePrefab).GetComponent<TMP_InputField>();
                dialogueNode.gameObject.transform.parent = FindObjectOfType<DialogueEditor>().gameObject.transform;
                //    dialogueNode.text = dialogueSystem.parsedDialogue[j].dialogue;
                dialogue.character = characterText.text;
                dialogue.dialogue = dialogueNode.text;
                dialogue.stage = gameObject.GetComponent<StageGrabber>().stageValue;
                dialogue.replies = new List<string>();
                dialogue.nextStage = new List<int>();
                int indexToInsert = 0;

                for (int i = 0; i < parsedDialogue.Count; i++)
                {

                    if (parsedDialogue[i].character == dialogue.character)
                    {
                        //if (dialogue.stage < parsedDialogue[j].stage)
                        //{
                        //    indexToInsert = j;
                        //}
                        //else if(dialogue.stage > parsedDialogue[j].stage)
                        //{
                        //    indexToInsert = j+1;
                        //}
                        indexToInsert = i+1;
                    }
                }
                parsedDialogue.Insert(indexToInsert, dialogue);
                for (int j = 0; j < parsedDialogue.Count; j++)
                {
                    if (parsedDialogue[j].stage == dialogue.stage)
                    {
                        FindObjectOfType<DialogueEditor>().editableDialogues.Add(j);
                    }
                }


                dialogueNode.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 300, 0);
                dialogueNode.GetComponentInChildren<TextMeshProUGUI>().text
                        = "Stage: " + dialogue.stage.ToString();
                dialogueNode.GetComponent<StageGrabber>().stageValue = dialogue.stage;

                LineRenderer line = Instantiate(lineRendererPrefab);
                line.positionCount = 2;
                line.SetPosition(0, gameObject.transform.position);
                line.SetPosition(1, dialogueNode.transform.position);
                line.GetComponent<LineInformation>().startObject = gameObject;
                line.GetComponent<LineInformation>().endObject = dialogueNode.gameObject;
            }
        }
    }
}
