using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelEditHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyDialogueNodes()
    {
        GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("DialogueNode");

        for (int i = 0; i < toDestroy.Length; i++)
        {
            Destroy(toDestroy[i]);
        }
        Destroy(this.gameObject);

        FindObjectOfType<CharacterButtonHandler>().enabled = false;
    }

}
