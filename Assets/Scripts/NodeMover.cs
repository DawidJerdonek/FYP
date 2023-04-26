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
        characterText  = GameObject.FindGameObjectWithTag("NameDisplay").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        parsedDialogue = FindObjectOfType<DialogueSystemNew>().parsedDialogue;
        cameraDistanceZ = camera.WorldToScreenPoint(transform.position).z;
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

            if (pathExists == false) //If a dialogue node already exists from a reply node
            {
                //Setup all new values for the new node
                Dialogue dialogue = new Dialogue();
                TMP_InputField dialogueNode = Instantiate(dialogueNodePrefab).GetComponent<TMP_InputField>();
                dialogueNode.gameObject.transform.parent = FindObjectOfType<DialogueEditor>().gameObject.transform;
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
                        indexToInsert = i+1; //increment by one to make the stage a new unique stage
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

                //Setup all the new lines connecting nodes
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
