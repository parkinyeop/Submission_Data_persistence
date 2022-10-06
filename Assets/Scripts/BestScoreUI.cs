using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class BestScoreUI : MonoBehaviour
{
    Button startButton;
    Button quitButton;
    public Text bestScoreText;

    private void Start()
    {
        startButton = transform.GetChild(2).GetComponent<Button>();
        quitButton = transform.GetChild(3).GetComponent<Button>();

        startButton.onClick.AddListener(StartNew);
        quitButton.onClick.AddListener(Exit);
        
        bestScoreText.text = MainManager.Inst.BestScore.text;
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Start New");
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
