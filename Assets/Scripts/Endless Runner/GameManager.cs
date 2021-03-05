using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform thePlatformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    public float distance;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = thePlatformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer.transform.position.z > distance)
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        theScoreManager.dead = true;
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        thePlatformGenerator.position = platformStartPoint;

        theScoreManager.scoreCount = 0;
        theScoreManager.dead = false;
    }
}
