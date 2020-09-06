using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    static int score;
    static Text scoreText;
    const string scorePrefix = "Score: ";
    Text ballsLeftText;
    const string ballsLeftPrefix = "Balls Left: ";

    static int ballsLeft;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreText.text = scorePrefix + score;

        ballsLeft = ConfigurationUtils.TotalBalls;
        ballsLeftText = GameObject.FindGameObjectWithTag("NumBalls").GetComponent<Text>();
        ballsLeftText.text = ballsLeftPrefix + ballsLeft;

        EventManager.AddPointsEventListener(AddScore);
        EventManager.AddReduceBallsEventListener(DecrementBalls);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scorePrefix + score;
        ballsLeftText.text = ballsLeftPrefix + ballsLeft;
    }

    /// <summary>
    /// increments score
    /// </summary>
    /// <param name="points"></param>
    void AddScore(int points)
    {
        score += points;
        scoreText.text = scorePrefix + score;
    }

    /// <summary>
    /// decreases the number of ball text
    /// </summary>
    void DecrementBalls()
    {
        ballsLeft--;
    }
}
