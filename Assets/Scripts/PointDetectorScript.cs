using UnityEngine;

public class PointDetectorScript : MonoBehaviour
{
    public LogicScript logic;

    public AudioSource passThroughSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    // void Update()
    // {
    // }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);
            // logic.high_Score();
            passThroughSound.Play();
        }
    }
}
