using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class BestScoreUI : MonoBehaviour
{
    Button startButton;
    Button quitButton;
    public TextMeshProUGUI bestScoreText;
    TMP_InputField inputField;

    private void Start()
    {
        startButton = transform.GetChild(2).GetComponent<Button>();
        quitButton = transform.GetChild(3).GetComponent<Button>();

        startButton.onClick.AddListener(StartNew);
        quitButton.onClick.AddListener(Exit);
        inputField = GetComponentInChildren<TMP_InputField>();

        inputField.onEndEdit.AddListener(OnInputName);
    }

    private void OnInputName(string name)
    {
        ScoreManager.Inst.bestName = name;
        bestScoreText.text = $"Best Score : {ScoreManager.Inst.bestScore} Name: {ScoreManager.Inst.bestName}";
        ScoreManager.Inst.SaveGameData();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(0);
        //Debug.Log("Start New");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
