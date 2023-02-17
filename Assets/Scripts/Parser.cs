using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEditor.SceneManagement;
using UnityEngine;

[System.Serializable]
public struct Dialogue
{
    public string character;
    public int stage;
    public string dialogue;
    public List<string> replies;
    public List<int> nextStage;
}

public class Parser : MonoBehaviour
{
    public bool isChecking;
    private string[] importedDialogueFile;
    public List<Dialogue> dialogueList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadData(string[] dataToLoad)
    {
        importedDialogueFile = dataToLoad;
        splitData();
        returnDialogue();
    }

    public void splitData()
    {
 
        Dialogue dialogue = new Dialogue();
        dialogue.replies = new List<string>();
        dialogue.nextStage = new List<int>();   
        bool continueSearch = false;
        string nameString = "";

        for (int i = 0; i < importedDialogueFile.Length; i++)
        {
           
            if (importedDialogueFile[i].Contains("<conversation>"))
            {
                nameString = importedDialogueFile[i];

                //Remove XML syntax to help with sorting data
                nameString = nameString.Replace("<conversation>", "");

                //Convert string to int
                dialogue.character = nameString;
            }
            if (importedDialogueFile[i].Contains("<dialogue>"))
            {
                continueSearch = true; //Seperate search for multiple Dialogues with one character
            }

            //Dialogue is handled with stages, load these in first
            if (importedDialogueFile[i].Contains("<stage>"))
            {
                //Store each line of XML as in array
                string modifiedString = importedDialogueFile[i];

                //Remove XML syntax to help with sorting data
                modifiedString = modifiedString.Replace("</stage>", "");
                modifiedString = modifiedString.Replace("<stage>", "");

                //Convert string to int
                dialogue.stage = int.Parse(modifiedString);
                dialogue.character = nameString;
            }

            if (continueSearch)
            {
                if (importedDialogueFile[i].Contains("<text>"))
                {
                    //Store each line of XML as in array
                    string modifiedString = importedDialogueFile[i];

                    //Remove XML syntax to help with sorting data
                    modifiedString = modifiedString.Replace("</text>", "");
                    modifiedString = modifiedString.Replace("<text>", "");

                    dialogue.dialogue = modifiedString;
                }
                else if(importedDialogueFile[i].Contains("<reply>"))
                {
                    //Store each line of XML as in array
                    string modifiedString = importedDialogueFile[i];

                    //Remove XML syntax to help with sorting data
                    modifiedString = modifiedString.Replace("</reply>", "");
                    modifiedString = modifiedString.Replace("<reply>", "");

                    //Add replies to the list of replies
                    dialogue.replies.Add(modifiedString);
                }
                else if (importedDialogueFile[i].Contains("<nextStage>"))
                {
                    //Store each line of XML as in array
                    string modifiedString = importedDialogueFile[i];

                    //Remove XML syntax to help with sorting data
                    modifiedString = modifiedString.Replace("</nextStage>", "");
                    modifiedString = modifiedString.Replace("<nextStage>", "");

                    //Convert string to int
                    dialogue.nextStage.Add(int.Parse(modifiedString));
                }

                if (importedDialogueFile[i].Contains("</dialogue>"))
                {
                    continueSearch = false;
                    dialogueList.Add(dialogue);
                    dialogue = new Dialogue { replies = new List<string>(), dialogue = "", stage = 0, nextStage = new List<int>(), character = "" };

                   
                }
            }
            
        }
    }


    public List<Dialogue> returnDialogue()
    {
        return dialogueList;
    }
}
