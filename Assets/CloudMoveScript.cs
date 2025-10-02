using UnityEngine;

public class CloudMoveScript : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position = transform.position + (Vector3.left * (ObstacleMoveScript.moveSpeed + 2.0f)) * Time.deltaTime;

        if (transform.position.x < -90f)
        {
            // Debug.Log("Obstacle Deleted");
            Destroy(gameObject);
        }
    }
}
