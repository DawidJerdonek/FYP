using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDUIManager : MonoBehaviour
{
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

        saveFileOneButton.SetActive(false);
        saveFileTwoButton.SetActive(false);
        saveFileThreeButton.SetActive(false);
        loadFileOneButton.SetActive(false);
        loadFileTwoButton.SetActive(false);
        loadFileThreeButton.SetActive(false);
        cancelButton.SetActive(false);
    }

    public void ShowSaves()
    {
        saveFileOneButton.SetActive(true);
        saveFileTwoButton.SetActive(true);
        saveFileThreeButton.SetActive(true);
        cancelButton.SetActive(true);
    }

    public void ShowLoads()
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
