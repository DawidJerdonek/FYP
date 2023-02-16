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
    public static DialogueSystem instance;

    public TextMeshProUGUI displayText;

    public string[] loadedDialogueFile;

    public GameObject observerCharacter;
    public GameObject greetingBotCharacter;   
    public GameObject missionControlCharacter;

    //public List<String> greetingBotDialogue;
    //public List<String> MissionDialogue;

    //public List<string> conversation;
    // public List<string> replies;
    // public int numOfResponses = 0;
    //public int nextStage = 0;

    public List<Dialogue> observerDialogue;
    public List<Dialogue> greetingBotDialogue;
    public List<Dialogue> missionControlDialogue;

    public List<Dialogue> parsedDialogue;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        loadedDialogueFile = readTextFile("Assets/Resources/DialogueTree.xml");

        parser.loadData(loadedDialogueFile);
        parsedDialogue = parser.returnDialogue();
        Debug.Log(parsedDialogue[0].character);

        //Dialogue tempDialogue = new Dialogue();
        //for (int i = 0; i < parsedDialogue.Count; i++)
        //{

        //    if (parsedDialogue[i].character == "Observer")
        //    {
        //        observerDialogue.AddRange(parsedDialogue);
        //        observerDialogue[i] = parsedDialogue[i];

        //        //String character = parsedDialogue[i].character;
        //        //String dialogue = parsedDialogue[i].dialogue;
        //        //observerDialogue.Add(tempDialogue);
        //        //dialogue = new Dialogue { replies = new List<string>(), dialogue = "", stage = 0 };
        //    }

        //    if (parsedDialogue[i].character == "GreetingBot")
        //    {
        //        greetingBotDialogue.AddRange(parsedDialogue);
        //        greetingBotDialogue[i] = parsedDialogue[i];
        //    }

        //    if (parsedDialogue[i].character == "MissionControl")
        //    {
        //        missionControlDialogue.AddRange(parsedDialogue);
        //        missionControlDialogue[i] = parsedDialogue[i];
        //    }
        //}
        //Debug.Log(observerDialogue[2].dialogue);
        //Debug.Log(greetingBotDialogue[1].dialogue);
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
