using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using UnityEngine.UI;
#if UNITY_EDITOR //preprocessor directives
using UnityEditor; //this namespace is NOT included in player builds!!!
using TMPro;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text highScoreText;
    public string highScoreName;
    public SaveData savedData;
    public int highScore;

    private void Start()
    {
        savedData = GameObject.Find("Persistence").GetComponent<SaveData>(); //data persistence between sessions
        savedData.LoadHighScore();

        highScore = savedData.highScore;
        highScoreName = savedData.highScoreName;

        highScoreText.text = "Best Score: " + highScoreName + ": " + highScore;
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR //conditional compiling
        EditorApplication.ExitPlaymode(); //quits play mode when in Unity editor
#else
        Application.Quit(); //original code to quit application
#endif
    }
}
