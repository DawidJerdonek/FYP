using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SaveEditHandler : MonoBehaviour
{
    private List<TMP_InputField> inputFields = new List<TMP_InputField>();
    // Start is called before the first frame update
    void Start()
    {
        inputFields = FindObjectsOfType<TMP_InputField>().ToList();
        inputFields.Reverse();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveAndDestroyDialogueNodes()
    {

        GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("DialogueNode");
        FindObjectOfType<DialogueEditor>().characterNameText.enabled = false;
        Dialogue dialogue = new Dialogue();

        for (int i = 0; i < inputFields.Count; i++)
        {
            int index = FindObjectOfType<DialogueEditor>().editableDialogues[i];
            dialogue = FindObjectOfType<DialogueSystemNew>().parsedDialogue[index];
            dialogue.dialogue = inputFields[i].text;
            FindObjectOfType<DialogueSystemNew>().parsedDialogue[index] = dialogue;


        }

        for (int i = 0; i < toDestroy.Length; i++)
        {
            Destroy(toDestroy[i]);
        }
        Destroy(gameObject);

       
    }
}
