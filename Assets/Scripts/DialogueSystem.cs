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

    public TextMeshProUGUI characterName;
    public TextMeshProUGUI displayText;

    public TextMeshProUGUI choice1Text;
    public TextMeshProUGUI choice2Text;

    public string[] loadedDialogueFile;

    public int observerStage;
    public int greetingBotStage;   
    public int missionControlStage;

    public List<int> characterStage;

    public List<string> replyOptions;
    public List<int> replyStage;

    public List<string> characterIdentity;

    public List<Dialogue> observerDialogue;
    public List<Dialogue> greetingBotDialogue;
    public List<Dialogue> missionControlDialogue;

    public List<Dialogue> parsedDialogue;
    public List<Dialogue> previewedparsedDialogueFile;

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

        //parser.loadData(loadedDialogueFile);
        parsedDialogue = parser.returnDialogue();

        //get rid
        for (int i = 0; i < parsedDialogue.Count; i++)
        {
            if (parsedDialogue[i].character == characterIdentity[0])
            {
                observerDialogue.Add(parsedDialogue[i]);
            }
            if (parsedDialogue[i].character == characterIdentity[1])
            {
                greetingBotDialogue.Add(parsedDialogue[i]);
            }
            if (parsedDialogue[i].character == characterIdentity[2])
            {
                missionControlDialogue.Add(parsedDialogue[i]);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

        //if (player.currentCharacter == characterIdentity[0])
        //{
        //    characterName.text = player.currentCharacter;
        //    displayText.text = observerDialogue[observerStage].dialogue;
        //    displayText.text = parsedDialogue[parsedDialogue[0].stage].dialogue;
        //    if (observerDialogue[observerStage].replies.Count > 0)
        //    {

        //        DialogueChoice(characterIdentity[0]);

        //    }
        //}
        //else if (player.currentCharacter == characterIdentity[1])
        //{
        //    characterName.text = player.currentCharacter;
        //    displayText.text = greetingBotDialogue[greetingBotStage].dialogue;
        //    if (greetingBotDialogue[greetingBotStage].replies.Count > 0)
        //    {

        //        DialogueChoice(characterIdentity[1]);

        //    }
        //}
        //else if (player.currentCharacter == characterIdentity[2])
        //{
        //    characterName.text = player.currentCharacter;
        //    displayText.text = missionControlDialogue[missionControlStage].dialogue;
        //    if (missionControlDialogue[missionControlStage].replies.Count > 0)
        //    {

        //        DialogueChoice(characterIdentity[2]);

        //    }
        //}


    }

    void DialogueChoice(string character)
    {
        if (player.currentCharacter == character)
        {

            choice1Text.text = observerDialogue[observerStage].replies[0];
            choice2Text.text = observerDialogue[observerStage].replies[1];

            if (Input.GetKeyDown(KeyCode.P))
            {
                observerStage = observerDialogue[observerStage].nextStage[0];
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                observerStage = observerDialogue[observerStage].nextStage[1];
            }
        }
        else if (player.currentCharacter == character)
        {
            //choice1Text.text = replyOptions[0];
            //choice2Text.text = replyOptions[1];

            if (Input.GetKeyDown(KeyCode.P))
            {
                greetingBotStage = greetingBotDialogue[greetingBotStage].nextStage[0];
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                greetingBotStage = greetingBotDialogue[greetingBotStage].nextStage[1];
            }
        }
        else if (player.currentCharacter == character)
        {
            displayText.text = missionControlDialogue[missionControlStage].dialogue;
 
            //choice1Text.text = replyOptions[0];
            //choice2Text.text = replyOptions[1];

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

    public void loadNewDialogue()
    {
        parsedDialogue.Clear();
        observerDialogue.Clear();
        greetingBotDialogue.Clear();
        missionControlDialogue.Clear();

       //parser.loadData(loadedDialogueFile);
        parsedDialogue = parser.returnDialogue();

        for (int i = 0; i < parsedDialogue.Count; i++)
        {
            if (parsedDialogue[i].character == characterIdentity[0])
            {
                observerDialogue.Add(parsedDialogue[i]);
            }
            if (parsedDialogue[i].character == characterIdentity[1])
            {
                greetingBotDialogue.Add(parsedDialogue[i]);
            }
            if (parsedDialogue[i].character == characterIdentity[2])
            {
                missionControlDialogue.Add(parsedDialogue[i]);
            }

        }
    }

    public string[] readTextFile(string filePath)
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
