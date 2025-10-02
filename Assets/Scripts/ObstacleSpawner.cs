using System;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject bird;
    public GameObject obstacle;
    public float heightOffset = 10;
    public float currentDistance;
    public GameObject currentObj;

    public float offset = 100;
    public float minOffSet;

    public float initialSpeed = 8f;
    public int increaseObstacleSpeedPer = 10;
    public static int totalObstacles = 0;

    public CloudSpawner cloudSpawner;


    void Start()
    {
        totalObstacles = 0;
        ObstacleMoveScript.moveSpeed = initialSpeed;
        spawnObstacle();
        currentDistance = Mathf.Abs(currentObj.transform.position.x - bird.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {

        currentDistance = Mathf.Abs(currentObj.transform.position.x - bird.transform.position.x);
        if (currentDistance < offset)
        {
            spawnObstacle();
        }
    }

    void spawnObstacle()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        currentObj = Instantiate(obstacle, new Vector3(transform.position.x, UnityEngine.Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        cloudSpawner.spawn();

        totalObstacles++;

        if (totalObstacles % increaseObstacleSpeedPer == 0 && offset >= minOffSet)
        {
            ObstacleMoveScript.moveSpeed += 1.5f;
            offset--;
        }
     }
}
