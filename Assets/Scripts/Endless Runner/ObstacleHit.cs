using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    public float obstaclePenalty;
    private ScoreManager theScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            theScoreManager.addErrorCount();
            theScoreManager.applyPenalty(obstaclePenalty);
            gameObject.SetActive(false);
        }
    }
}
