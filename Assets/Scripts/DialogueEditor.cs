using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueEditor : MonoBehaviour
{
    public GameObject dialogueEditor;

    public TMP_InputField editable;
    //public TextMeshProUGUI characterName;
    public string[] dialogueFile;

    // Start is called before the first frame update
    void Start()
    {
        dialogueFile = readTextFile("Assets/Resources/DialogueTree.xml");
        for (int i = 0; i < dialogueFile.Length; i++)
        {
            editable.text += dialogueFile[i];
            editable.text += "\n";
        }
        Debug.Log(editable.text);
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

    public void ToSaveFileOne()
    {
        System.IO.File.WriteAllText("Assets/Resources/DialogueTreeCustom1.xml", editable.text);
    }
    public void ToSaveFileTwo()
    {
        System.IO.File.WriteAllText("Assets/Resources/DialogueTreeCustom2.xml", editable.text);
    }
    public void ToSaveFileThree()
    {
        System.IO.File.WriteAllText("Assets/Resources/DialogueTreeCustom3.xml", editable.text);
    }
}
