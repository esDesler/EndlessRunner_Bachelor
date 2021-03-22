using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    public float obstaclePenalty;
    private ScoreManager theScoreManager;

    private AudioSource obstacleHitSound;
    
    // Start is called before the first frame update
    void Start()
    {
        obstacleHitSound = GameObject.Find("Jump_02").GetComponent<AudioSource>();
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            theScoreManager.addErrorCount();
            theScoreManager.applyPenalty(obstaclePenalty);
            gameObject.SetActive(false);
            obstacleHitSound.Play();
        }
    }
}
