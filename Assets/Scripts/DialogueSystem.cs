using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System.Linq;
using System;

public class DialogueSystem : MonoBehaviour
{
    public PlayerController player;
    public Parser parser;
    public static DialogueSystem instance;

    public TextMeshProUGUI displayText;

    public string[] loadedDialogueFile;

    public int observerStage;
    public int greetingBotStage;   
    public int missionControlStage;

    public List<string> replyOptions;
    public List<int> replyStage;

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
                observerDialogue.Add(parsedDialogue[i]);
            }
            if (parsedDialogue[i].character == "GreetingBot")
            {
                greetingBotDialogue.Add(parsedDialogue[i]);
            }
            if (parsedDialogue[i].character == "MissionControl")
            {
                missionControlDialogue.Add(parsedDialogue[i]);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        //COmment out for presentation
        if (player.currentCharacter == "Observer")
        {
            displayText.text = observerDialogue[observerStage].dialogue;
            if (observerDialogue[observerStage].replies.Count > 0)
            {

                DialogueChoice();

            }
        }
        else if (player.currentCharacter == "GreetingBot")
        {
            displayText.text = greetingBotDialogue[greetingBotStage].dialogue;
            if (greetingBotDialogue[greetingBotStage].replies.Count > 0)
            {

                DialogueChoice();

            }
        }
        else if (player.currentCharacter == "MissionControl")
        {
            displayText.text = greetingBotDialogue[greetingBotStage].dialogue;
            if (greetingBotDialogue[greetingBotStage].replies.Count > 0)
            {

                DialogueChoice();

            }
        }


    }

    void DialogueChoice()
    {
        if (player.currentCharacter == "Observer")
        {

            for (int i = 0; i < observerDialogue[observerStage].replies.Count - 1; i++)
            {
                replyOptions.Add(observerDialogue[observerStage].replies[i]);
                replyStage.Add(observerDialogue[observerStage].nextStage[i]);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                observerStage = observerDialogue[observerStage].nextStage[0];
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                observerStage = observerDialogue[observerStage].nextStage[1];
            }
        }
        else if (player.currentCharacter == "GreetingBot")
        {
            displayText.text = greetingBotDialogue[greetingBotStage].dialogue;
            for (int i = 0; i < greetingBotDialogue[greetingBotStage].replies.Count - 1; i++)
            {
                replyOptions.Add(greetingBotDialogue[greetingBotStage].replies[i]);
                replyStage.Add(greetingBotDialogue[greetingBotStage].nextStage[i]);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                greetingBotStage = greetingBotDialogue[greetingBotStage].nextStage[0];
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                greetingBotStage = greetingBotDialogue[greetingBotStage].nextStage[1];
            }
        }
        else if (player.currentCharacter == "MissionControl")
        {
            displayText.text = missionControlDialogue[missionControlStage].dialogue;
            for (int i = 0; i < missionControlDialogue[missionControlStage].replies.Count - 1; i++)
            {
                replyOptions.Add(missionControlDialogue[missionControlStage].replies[i]);
                replyStage.Add(missionControlDialogue[missionControlStage].nextStage[i]);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                missionControlStage = missionControlDialogue[missionControlStage].nextStage[0];
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                missionControlStage = missionControlDialogue[missionControlStage].nextStage[1];
            }
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
