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
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        cameraDistanceZ = camera.WorldToScreenPoint(transform.position).z;
        stage = GetComponentInParent<StageGrabber>().stageValue;
        deleteButton.SetActive(false);
        addButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        parsedDialogue = FindObjectOfType<DialogueSystemNew>().parsedDialogue;
        cameraDistanceZ = camera.WorldToScreenPoint(transform.position).z;
        for (int i = 0; i < parsedDialogue.Count; i++)
        {
            if (parsedDialogue[i].replies.Count == 0)
            {
                deleteButton.SetActive(true);
                addButton.SetActive(true);
            }
            else
            {

            }
        }
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
        TextMeshProUGUI characterText = GameObject.FindGameObjectWithTag("NameDisplay").GetComponent<TextMeshProUGUI>();
        
        for(int i = 0; i< parsedDialogue.Count; i++)
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

    }
}
