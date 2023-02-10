using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System.Linq;
using System;

public class DialogueSystem : MonoBehaviour
{
    public Parser parser;

    public TextMeshProUGUI tempText;

    public string[] loadedDialogueFile;

    public List<String> observerDialogue;
    //public List<String> greetingBotDialogue;
    //public List<String> MissionDialogue;

    //public List<string> conversation;
    // public List<string> replies;
    // public int numOfResponses = 0;
    //public int nextStage = 0;

    public List<Dialogue> parsedDialogue;
    // Start is called before the first frame update
    void Start()
    {
        loadedDialogueFile = readTextFile("Assets/Resources/DialogueTree.xml");
        Debug.Log(loadedDialogueFile);
        //parser.loadData(loadedDialogueFile);

        //string temp = "";

        //foreach (string item in loadedDialogueFile)
        //{
        //    temp += item + "\n";
        //}

        //tempText.text = temp;

        parser.loadData(loadedDialogueFile);
        parsedDialogue = parser.returnDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string[] readTextFile(string filePath)
    {
        int length = 0;
        List<string> lines = new List<string>();

        foreach (string line in System.IO.File.ReadLines(filePath))
        {
            lines.Add(line);
            length++;
        }

        return lines.ToArray();
    }
}
