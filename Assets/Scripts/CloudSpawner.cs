using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public float xSpawnRange;
    public float ySpawnRange;
    public int maxClouds;

    public GameObject cloud;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawn();
    }

    public void spawn()
    {
        int currClouds = Random.Range(0, maxClouds);

        float currYPos = Random.Range(0, 0 + ySpawnRange);
        for (int i = 0; i < currClouds; i++)
        {
            Instantiate(cloud, new Vector3(transform.position.x, currYPos, 0), Quaternion.identity);
        }
    }
}
