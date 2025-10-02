using UnityEngine;

public class ObstacleMoveScript : MonoBehaviour
{
    public ObstacleSpawner obsticleSpawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static float moveSpeed = 3;

    public float deadZone = -30;
    void Start()
    {
        obsticleSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ObstacleSpawner>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            // Debug.Log("Obstacle Deleted");
            Destroy(gameObject);
        }
    }
}
