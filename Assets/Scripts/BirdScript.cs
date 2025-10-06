using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool gameOver;
    public bool birdIsAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) == true || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0)) && birdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle" && !gameOver)
        {
            logic.gameOver();
            birdIsAlive = false;
            gameOver = true;
        }
    }
}
