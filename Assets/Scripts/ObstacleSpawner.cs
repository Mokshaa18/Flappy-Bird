using System;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject bird;
    public GameObject obstacle;
    public float heightOffset = 10;
    public float currentDistance;
    public GameObject currentObj;

    public float spawnDistance;
    public float offSetRate;

    public float currOffSet;
    public float maxOffSet;

    public float initialSpeed = 8f;
    public int increaseObstacleSpeedPer = 10;
    public static int totalObstacles = 0;

    public CloudSpawner cloudSpawner;


    void Start()
    {
        totalObstacles = 0;
        currOffSet = 0;
        ObstacleMoveScript.moveSpeed = initialSpeed;
        spawnObstacle();
        currentDistance = Mathf.Abs(currentObj.transform.position.x - bird.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {

        currentDistance = Mathf.Abs(currentObj.transform.position.x - bird.transform.position.x);
        float dynamicSpawnDistance = spawnDistance + (ObstacleMoveScript.moveSpeed * 0.8f);
        if (currentDistance < dynamicSpawnDistance)
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

        if (totalObstacles % increaseObstacleSpeedPer == 0 && currOffSet <= maxOffSet)
        {
            ObstacleMoveScript.moveSpeed += 1f;
            transform.position += new Vector3(offSetRate, 0, 0);
            currOffSet += 1;
        }
     }
}
