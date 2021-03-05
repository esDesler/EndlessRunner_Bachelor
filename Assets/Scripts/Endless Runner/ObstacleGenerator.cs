using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public float offsetRange;

    public Transform generationPoint;

    private int obstacleSelector;

    public ObjectPooler[] theObstaclePools;

    private void Update()
    {
        if (transform.position.z < generationPoint.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);

            obstacleSelector = Random.Range(0, theObstaclePools.Length);

            GameObject newPlatform = theObstaclePools[obstacleSelector].getPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
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
