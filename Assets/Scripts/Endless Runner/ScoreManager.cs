using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public float highScoreCount;
    public float errorsCount;

    public float pointsPerSecond;

    public bool dead;

    private string highScoreKey = "HighScore";

    // Start is called before the first frame update
    void Start()
    {
        highScoreCount = PlayerPrefs.GetFloat(highScoreKey, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat(highScoreKey, highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
    }

    public void addErrorCount()
    {
        errorsCount++;
    }

    public void applyPenalty(float amount)
    {
        scoreCount -= amount;
    }
}
