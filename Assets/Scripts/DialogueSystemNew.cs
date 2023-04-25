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

    public int currentStage;

    public List<int> characterStage;

    public List<string> replyOptions;
    public List<int> replyStage;

    public List<string> characterIdentity;

    public List<Dialogue> parsedDialogue;
    public List<Dialogue> previewedparsedDialogueFile;

    private bool choiceMade = false;

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
            characterStage.Add(parsedDialogue[i].stage);
        }

        //Populate Character Identities using Parsed Dialogue
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
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.colliding)
            {
                DialogueChoice(player.currentCharacter);
            }
        }
        choiceMade = false;
    }

    public void DialogueChoice(string character)
    {

        for (int i = 0; i < parsedDialogue.Count; i++)
        {
            if (parsedDialogue[i].character == character)
            {
                if (parsedDialogue[i].stage == currentStage)
                {
                    displayText.text = parsedDialogue[i].dialogue;


                    for (int j = 0; j < parsedDialogue[i].replies.Count; j++)
                    {

                        choice1Text.text = parsedDialogue[i].replies[0];
                        choice2Text.text = parsedDialogue[i].replies[1];

                        if (choiceMade == false)
                        {
                            if (Input.GetKeyDown(KeyCode.P))
                            {
                                currentStage = parsedDialogue[i].nextStage[0];
                                Debug.Log("True");
                                choiceMade = true;
                            }
                            else if (Input.GetKeyDown(KeyCode.L))
                            {
                                currentStage = parsedDialogue[i].nextStage[1];
                                Debug.Log("False");
                                choiceMade = true;
                            }
                        }
                    }
                }
            }
        }
    }

    public void loadNewDialogue()
    {
        parsedDialogue.Clear();

        parser.loadData(loadedDialogueFile);
        parsedDialogue = parser.returnDialogue();
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
