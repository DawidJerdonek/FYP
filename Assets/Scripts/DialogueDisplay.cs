using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueDisplay : MonoBehaviour
{
    public GameObject characterName;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
       player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        characterName.GetComponent<TextMeshProUGUI>().text = player.currentCharacter;
    }
}
