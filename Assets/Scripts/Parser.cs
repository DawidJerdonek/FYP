using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    private List<string> importedDialogueFile;
    public List<Dialogue> dialogueList;

    public List<string> reformattingList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadData(List<string> dataToLoad)
    {
        importedDialogueFile = dataToLoad;
        splitData();
        returnDialogue();
        ReformatIntoXML();
    }

    public void splitData()
    {
 
        Dialogue dialogue = new Dialogue();
        dialogue.replies = new List<string>();
        dialogue.nextStage = new List<int>();   
        bool continueSearch = false;
        string nameString = "";

        for (int i = 0; i < importedDialogueFile.Count; i++)
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

    public void ReformatIntoXML()
    {
        List<Dialogue> currentParsedDialogue = dialogueList;
        string previousCharacter = "";
        reformattingList.Clear();
        reformattingList.Add("<?xml version=\"1.0\" encoding=\"utf-8\"?>");

        for (int i = 0; i < currentParsedDialogue.Count; i++)
        {
            //If first character
            if(i == 0)
            {
                previousCharacter = currentParsedDialogue[i].character;
                reformattingList.Add("<conversation>" + currentParsedDialogue[i].character);
            }
            else if(previousCharacter != currentParsedDialogue[i].character) //Check if next line is different character
            {
                previousCharacter = currentParsedDialogue[i].character;
                reformattingList.Add("</conversation>"); //End last character 
                reformattingList.Add("<conversation>" + currentParsedDialogue[i].character); //Start new next character
            }

            reformattingList.Add("<stage>" + currentParsedDialogue[i].stage + "</stage>"); //Add the dialogue stage
            reformattingList.Add("<dialogue>");
            reformattingList.Add("<text>"+ currentParsedDialogue[i].dialogue + "</text>"); //Add the dialogue for this stage
            for(int j = 0; j < currentParsedDialogue[i].replies.Count; j++)//Add all replies
            {
                reformattingList.Add("<reply>" + currentParsedDialogue[i].replies[j] + "</reply>");
                reformattingList.Add("<nextStage>" + currentParsedDialogue[i].nextStage[j] + "</nextStage>");
            }
            reformattingList.Add("</dialogue>"); //End character dialogue stage

            if(previousCharacter != currentParsedDialogue[i].character)
            {

            }
        }
        reformattingList.Add("</conversation>"); //End last character
    }
    public List<Dialogue> returnDialogue()
    {
        return dialogueList;
    }
}
