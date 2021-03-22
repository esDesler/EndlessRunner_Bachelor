using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public float offsetRange;

    public Transform generationPoint;

    private int obstacleSelector;

    public ObjectPooler[] theObstaclePools;

    //public NextObstacleQueue nextObjectQueue;

    private void Update()
    {
        if (transform.position.z < generationPoint.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 20);

            // For haptics testing purposes we are only using one obstacle type atm
            //obstacleSelector = Random.Range(0, theObstaclePools.Length);
            obstacleSelector = 2;

            GameObject newObstacle = theObstaclePools[obstacleSelector].getPooledObject();
            newObstacle.transform.position = transform.position;
            newObstacle.SetActive(true);

            //nextObjectQueue.Enqueue(newObstacle);
        }
    }

    public void spawnObstacle(Vector3 position)
    {
        float randomOffset = Random.Range(-offsetRange, offsetRange);

        GameObject obstacle1 = theObstaclePools[obstacleSelector].getPooledObject();
        position = new Vector3(position.x, position.y, position.z + randomOffset);
        obstacle1.transform.position = position;
        obstacle1.SetActive(true);

    }
}
