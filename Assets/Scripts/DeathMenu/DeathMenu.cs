using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public string mainMenu;

    public Text RunningScore;
    public Text ObstaclesHit;

    private ScoreManager theScoreManager;

    private void Awake()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    private void OnEnable()
    {
        RunningScore.text = "Running Score: " + Mathf.Round(theScoreManager.scoreCount);
        ObstaclesHit.text = "Obstacles Hit: " + theScoreManager.errorsCount;
    }
}
