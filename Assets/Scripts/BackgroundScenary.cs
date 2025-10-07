using System;
using UnityEngine;

public class BackgroundScenary : MonoBehaviour
{
    public LogicScript playerScore;
    public int scenarioChangePerObs = 10;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject[] images;

    private int currIndex = 0;
    private int track = 0;

    void Start()
    {
        images = new GameObject[] { image1, image2, image3 };
        // Scale all backgrounds to fit screen
        foreach (GameObject img in images)
        {
            FitBackgroundToScreen(img);
        }

        showBackGroundImage(currIndex);
    }

    void Update()
    {
        int score = playerScore.playerScore;

        if (score / scenarioChangePerObs > track)
        {
            track = score / scenarioChangePerObs;
            currIndex = (currIndex + 1) % images.Length;
            showBackGroundImage(currIndex);
        }
    }

    void showBackGroundImage(int index)
    {
        foreach (GameObject n in images)
        {
            n.SetActive(false);
        }

        images[index].SetActive(true);
    }

    void FitBackgroundToScreen(GameObject bg)
    {
        SpriteRenderer sr = bg.GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogError("SpriteRenderer not found on background: " + bg.name);
            return;
        }

        // Calculate world height and width of the camera
        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight * Screen.width / Screen.height;

        // Get sprite size
        Vector3 scale = bg.transform.localScale;
        scale.x = worldScreenWidth / sr.sprite.bounds.size.x;
        scale.y = worldScreenHeight / sr.sprite.bounds.size.y;
        bg.transform.localScale = scale;
    }
}
