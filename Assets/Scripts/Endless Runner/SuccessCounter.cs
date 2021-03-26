using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessCounter : MonoBehaviour
{
    private ScoreManager theScoreManager;

    private void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            theScoreManager.AddSuccessCount();
        }
    }

}
