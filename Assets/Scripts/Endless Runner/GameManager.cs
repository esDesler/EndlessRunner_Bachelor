using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] theObjectGenerators;
    private Vector3[] objectsStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    public float distance;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathMenu;

    public PauseMenu thePauseMenu;

    //public NextObstacleQueue nextObstacleQueue;

    private GameObject nextObstacle;

    private HapticsController theHapticsController;

    // Start is called before the first frame update
    void Start()
    {
        objectsStartPoint = new Vector3[theObjectGenerators.Length];

        for (int i = 0; i < theObjectGenerators.Length; i++)
        {
            objectsStartPoint[i] = theObjectGenerators[i].position;
        }
        
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();

        theHapticsController = FindObjectOfType<HapticsController>();


        // Get initial next object from queue
        //nextObstacle = nextObstacleQueue.Dequeue();
        // Send the nextObstacle to the haptics controller
        //theHapticsController.updateNextObstacle(nextObstacle);
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer.transform.position.z > distance)
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (thePauseMenu.isActiveAndEnabled)
            {
                thePauseMenu.ResumeGame();
            } else
            {
                thePauseMenu.PauseGame();
            }
        }

        /*if (thePlayer.transform.position.z > nextObstacle.transform.position.z)
        {
            nextObstacle = nextObstacleQueue.Dequeue();
            theHapticsController.updateNextObstacle(nextObstacle);
        }*/
    }

    public void RestartGame()
    {
        theScoreManager.dead = true;
        thePlayer.gameObject.SetActive(false);

        theDeathMenu.gameObject.SetActive(true);
    }

    public void Reset()
    {
        theDeathMenu.gameObject.SetActive(false);

        // Destroy objects so they can be reused when the game restarts
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        // Reset the players position
        thePlayer.transform.position = playerStartPoint;

        // Reset generation points
        for (int i = 0; i < theObjectGenerators.Length; i++)
        {
            theObjectGenerators[i].position = objectsStartPoint[i];
        }

        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.dead = false;
    }
}
