using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System.Linq;
using System;

public class DialogueSystemNew : MonoBehaviour
{
    public PlayerController player;
    public Parser parser;
    public static DialogueSystemNew instance;

    public TextMeshProUGUI characterName;
    public TextMeshProUGUI displayText;

    public TextMeshProUGUI choice1Text;
    public TextMeshProUGUI choice2Text;

    public List<string> loadedDialogueFile;

    public int observerStage;
    public int greetingBotStage;
    public int missionControlStage;

    public List<int> characterStage;

    public List<string> replyOptions;
    public List<int> replyStage;

    public List<string> characterIdentity;

    public List<List<Dialogue>> characterDialogues;

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

        characterDialogues = new List<List<Dialogue>>();

        loadedDialogueFile = readTextFile("Assets/Resources/DialogueTree.xml");

        parser.loadData(loadedDialogueFile);
        parsedDialogue = parser.returnDialogue();
        Debug.Log(parsedDialogue[0].character);

        for (int i = 0; i < parsedDialogue.Count; i++)
        {
            characterStage.Add(parsedDialogue[i].stage);
        }

        int j = 0;
        for (int i = 0; i < parsedDialogue.Count; i++)
        {
            if (characterIdentity.Contains(parsedDialogue[i].character))
            {

            }
            else
            {
                characterIdentity.Add(parsedDialogue[i].character);
            }
        }

        //for (int i = 0; i < parsedDialogue.Count; i++)
        //{
        //    if (parsedDialogue[i].character == characterIdentity[0])
        //    {
        //        characterDialogues[0].Add(parsedDialogue[i]);
        //    }
        //    if (parsedDialogue[i].character == characterIdentity[1])
        //    {
        //        characterDialogues[1].Add(parsedDialogue[i]);
        //    }
        //    if (parsedDialogue[i].character == characterIdentity[2])
        //    {
        //        characterDialogues[2].Add(parsedDialogue[i]);
        //    }

        //}


    }

    // Update is called once per frame
    void Update()
    {

        //if (player.currentCharacter == characterIdentity[0])
        //{
        //    characterName.text = player.currentCharacter;
        //    displayText.text = characterDialogues[0][observerStage].dialogue;

        //    if (characterDialogues[0][observerStage].replies.Count > 0)
        //    {

        //        DialogueChoice(characterIdentity[0]);

        //    }
        //}
        //else if (player.currentCharacter == characterIdentity[1])
        //{
        //    characterName.text = player.currentCharacter;
        //    displayText.text = characterDialogues[1][greetingBotStage].dialogue;

        //    if (characterDialogues[1][greetingBotStage].replies.Count > 0)
        //    {

        //        DialogueChoice(characterIdentity[1]);

        //    }
        //}
        //else if (player.currentCharacter == characterIdentity[2])
        //{
        //    characterName.text = player.currentCharacter;
        //    displayText.text = characterDialogues[2][missionControlStage].dialogue;
        //    if (characterDialogues[2][missionControlStage].replies.Count > 0)
        //    {

        //        DialogueChoice(characterIdentity[2]);

        //    }
        //}


    }

    void DialogueChoice(string character)
    {
        if (player.currentCharacter == character)
        {

            choice1Text.text = characterDialogues[0][observerStage].replies[0];
            choice2Text.text = characterDialogues[0][observerStage].replies[1];

            if (Input.GetKeyDown(KeyCode.P))
            {
                observerStage = characterDialogues[0][observerStage].nextStage[0];
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                observerStage = characterDialogues[0][observerStage].nextStage[1];
            }
        }
        else if (player.currentCharacter == character)
        {
            //choice1Text.text = replyOptions[0];
            //choice2Text.text = replyOptions[1];

            if (Input.GetKeyDown(KeyCode.P))
            {
                greetingBotStage = characterDialogues[1][greetingBotStage].nextStage[0];
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                greetingBotStage = characterDialogues[1][greetingBotStage].nextStage[1];
            }
        }
        else if (player.currentCharacter == character)
        {
            displayText.text = characterDialogues[1][missionControlStage].dialogue;

            //choice1Text.text = replyOptions[0];
            //choice2Text.text = replyOptions[1];

            if (Input.GetKeyDown(KeyCode.P))
            {
                missionControlStage = characterDialogues[1][missionControlStage].nextStage[0];
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                missionControlStage = characterDialogues[1][missionControlStage].nextStage[1];
            }
        }
    }

    public void loadNewDialogue()
    {
        parsedDialogue.Clear();
        characterDialogues.Clear();

        parser.loadData(loadedDialogueFile);
        parsedDialogue = parser.returnDialogue();

        for (int i = 0; i < parsedDialogue.Count; i++)
        {
            if (parsedDialogue[i].character == characterIdentity[0])
            {
                characterDialogues[0].Add(parsedDialogue[i]);
            }
            if (parsedDialogue[i].character == characterIdentity[1])
            {
                characterDialogues[1].Add(parsedDialogue[i]);
            }
            if (parsedDialogue[i].character == characterIdentity[2])
            {
                characterDialogues[2].Add(parsedDialogue[i]);
            }

        }
    }

    public List<string> readTextFile(string filePath)
    {
        int length = 0;
        List<string> lines = new List<string>();

        foreach (string line in System.IO.File.ReadLines(filePath))
        {
            lines.Add(line);
            length++;
        }

        return lines;
    }

}
