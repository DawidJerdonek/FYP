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

    public int observerStage;
    public int greetingBotStage;   
    public int missionControlStage;

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

        for (int i = 0; i < parsedDialogue.Count; i++)
        {
            if (parsedDialogue[i].character == "Observer")
            {
                //observerDialogue[j].character = parsedDialogue[i].character;
                observerDialogue.Add(parsedDialogue[i]);
            }
            if (parsedDialogue[i].character == "GreetingBot")
            {
                //observerDialogue[j].character = parsedDialogue[i].character;
                greetingBotDialogue.Add(parsedDialogue[i]);
            }
            if (parsedDialogue[i].character == "MissionControl")
            {
                //observerDialogue[j].character = parsedDialogue[i].character;
                missionControlDialogue.Add(parsedDialogue[i]);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = observerDialogue[observerStage].dialogue;
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P");
            observerStage++;
 
        }
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
