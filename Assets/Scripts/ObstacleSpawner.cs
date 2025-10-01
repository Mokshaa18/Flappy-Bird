using System;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnRate = 2;
    private float spawnTimer = 0;
    public float heightOffset = 10;
    public float currentDistance;
    public GameObject currentObj;
    public float initialSpawnRate;

    public float offset = 100;

    public float initialSpeed = 8f;
    public int obstaclesPerLevel = 10;
    public static int totalObstacles = 0;
    public float incrementPercent = 0.5f;
    public float maxMultiplier = 10f;

    // public int obstacleRate;
    // public float acceleration;
    // public float maxSpeed; 


    void Start()
    {
        totalObstacles = 0;
        ObstacleMoveScript.moveSpeed = initialSpeed;
        initialSpawnRate = spawnRate;
        InvokeRepeating("spawnObstacle", 0f, spawnRate);
        // spawnObstacle();
            
    }

    // Update is called once per frame
    void fUpdate()
    {

        if (currentDistance > offset)
        {
            spawnObstacle();
            currentDistance = 0;
        }
        else
        {
         currentDistance = Vector3.Distance(transform.position, currentObj.transform.position);
        }
    }

    void spawnObstacle()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        currentObj = Instantiate(obstacle, new Vector3(transform.position.x, UnityEngine.Random.Range(lowestPoint, highestPoint), 0), transform.rotation);

        totalObstacles++;

        int currentLevel = totalObstacles / obstaclesPerLevel;
        int obstaclesInLevel = totalObstacles % obstaclesPerLevel; // 0–9

        if (currentLevel == 0)
        {
            ObstacleMoveScript.moveSpeed = initialSpeed;
        }

        else
        {
            float currentLevelBaseSpeed = initialSpeed + ((currentLevel - 1) * initialSpeed * incrementPercent);
            float nextLevelSpeed = currentLevelBaseSpeed + (initialSpeed * incrementPercent);

            if (obstaclesInLevel < obstaclesPerLevel / 2)
            {
                float t = (float)obstaclesInLevel / (obstaclesPerLevel / 2);
                ObstacleMoveScript.moveSpeed = Mathf.SmoothStep(currentLevelBaseSpeed, (currentLevelBaseSpeed + nextLevelSpeed) / 2, t);
            }
            else
            {
                float t = (float)(obstaclesInLevel - obstaclesPerLevel / 2) / (obstaclesPerLevel / 2);
                ObstacleMoveScript.moveSpeed = Mathf.SmoothStep((currentLevelBaseSpeed + nextLevelSpeed) / 2, nextLevelSpeed, t);
            }

            float maxSpeed = initialSpeed * maxMultiplier;
            if (ObstacleMoveScript.moveSpeed > maxSpeed)
                ObstacleMoveScript.moveSpeed = maxSpeed;
        }
         Debug.Log("Total Obstacles" + totalObstacles + " Move Speed: " + ObstacleMoveScript.moveSpeed + " Current Level: " + currentLevel);

        // Either this --------------------------------------------------

        // int obstaclesInLevel = totalObstacles % obstaclesPerLevel; // 0–9
        // float currentLevelBaseSpeed = initialSpeed + ((totalObstacles / obstaclesPerLevel) * initialSpeed * incrementPercent);
        // float nextLevelSpeed = currentLevelBaseSpeed + (initialSpeed * incrementPercent);

        // if (obstaclesInLevel < obstaclesPerLevel / 2) // first half
        // {
        //     ObstacleMoveScript.moveSpeed = currentLevelBaseSpeed + (nextLevelSpeed - currentLevelBaseSpeed) / 2;
        // }
        // else // second half
        // {
        //     ObstacleMoveScript.moveSpeed = nextLevelSpeed;
        // }

        // // Cap check
        // float maxSpeed = initialSpeed * maxMultiplier;
        // if (ObstacleMoveScript.moveSpeed > maxSpeed)
        //     ObstacleMoveScript.moveSpeed = maxSpeed;

        // Debug.Log("Total Obstacles: " + totalObstacles + " | MoveSpeed: " + ObstacleMoveScript.moveSpeed);

        // Or that --------------------------------------------------
        // float currentSpeed = ObstacleMoveScript.moveSpeed;
        // float targetSpeed = currentSpeed + (initialSpeed * incrementPercent);
        // float maxSpeed = initialSpeed * maxMultiplier;
        // if (targetSpeed > maxSpeed) targetSpeed = maxSpeed;
        // int obstaclesInLevel = totalObstacles % obstaclesPerLevel;
        // float t = (float)obstaclesInLevel / obstaclesPerLevel;

        // ObstacleMoveScript.moveSpeed = Mathf.Lerp(currentSpeed, targetSpeed, t);
        // Debug.Log("Total ObstaclesL: " + totalObstacles + " and Move Speed: " + ObstacleMoveScript.moveSpeed + " and Target Speed: " + targetSpeed);

        // Till here --------------------------------------------------

        // if (totalObstacles % obstaclesPerLevel == 0)
        // {
        //     float nextSpeed = ObstacleMoveScript.moveSpeed + (initialSpeed * incrementPercent);

        //     Debug.Log("Next Speed: " + nextSpeed);
        //     float maxSpeed = initialSpeed * maxMultiplier;

        //     if (nextSpeed <= maxSpeed)
        //     {
        //         ObstacleMoveScript.moveSpeed = nextSpeed;
        //         Debug.Log("Increased Speed: " + ObstacleMoveScript.moveSpeed);
        //     }

        //     else
        //     {
        //         ObstacleMoveScript.moveSpeed = maxSpeed;
        //         Debug.Log("Max Speed Reached: " + ObstacleMoveScript.moveSpeed);
        //     }
        // }

    }
}
