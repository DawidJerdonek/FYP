using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDUIManager : MonoBehaviour
{
    public TextMeshProUGUI hideHUDPrompt;
    public bool HUDEnabled;

    public GameObject loadFileButton;
    public GameObject toggleSavesButton;

    public GameObject saveFileOneButton;
    public GameObject saveFileTwoButton;
    public GameObject saveFileThreeButton;
    public GameObject loadFileOneButton;
    public GameObject loadFileTwoButton;
    public GameObject loadFileThreeButton;
    public GameObject cancelButton;

    // Start is called before the first frame update
    void Start()
    {
        HUDEnabled = true;
        loadFileButton.SetActive(true);
        toggleSavesButton.SetActive(true);

        saveFileOneButton.SetActive(false);
        saveFileTwoButton.SetActive(false);
        saveFileThreeButton.SetActive(false);
        loadFileOneButton.SetActive(false);
        loadFileTwoButton.SetActive(false);
        loadFileThreeButton.SetActive(false);
        cancelButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)))
        {
            HUDEnabled ^= true;
        }

        loadFileButton.SetActive(HUDEnabled);
        toggleSavesButton.SetActive(HUDEnabled);
        hideHUDPrompt.enabled = HUDEnabled;
        //SaveFileOneButton.SetActive(HUDEnabled);
        //SaveFileTwoButton.SetActive(HUDEnabled);
        //SaveFileThreeButton.SetActive(HUDEnabled);
    }

    public void ShowSaves()
    {
        saveFileOneButton.SetActive(true);
        saveFileTwoButton.SetActive(true);
        saveFileThreeButton.SetActive(true);
        cancelButton.SetActive(true);
    }

    public void ShowLoadSaves()
    {
        loadFileOneButton.SetActive(true);
        loadFileTwoButton.SetActive(true);
        loadFileThreeButton.SetActive(true);
        cancelButton.SetActive(true);
    }

    public void Hide()
    {
        saveFileOneButton.SetActive(false);
        saveFileTwoButton.SetActive(false);
        saveFileThreeButton.SetActive(false);
        loadFileOneButton.SetActive(false);
        loadFileTwoButton.SetActive(false);
        loadFileThreeButton.SetActive(false);
        cancelButton.SetActive(false);
    }
}
