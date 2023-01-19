using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueEditor : MonoBehaviour
{
    public GameObject dialogueEditor;
    public GameObject observerCharacter;
    public GameObject missionControlCharacter;


    public List<String> observerDialogue;
    public List<String> greetingBotDialogue;
    public List<String> MissionDialogue;

    public TextMeshProUGUI editable;
    public TextMeshProUGUI greetingBotText;
    public TextMeshProUGUI characterName;

    // Start is called before the first frame update
    void Start()
    {
        greetingBotText.text = editable.text;
    }

    // Update is called once per frame
    void Update()
    {
     //for(int i = 0; i < observerDialogue.Count; i++)   
    }
}
