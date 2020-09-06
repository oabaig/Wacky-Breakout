using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    Ball ball;

    Timer ballSpawnTimer;

    bool retrySpawn = false;

    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    private void Start()
    {
        ballSpawnTimer = gameObject.AddComponent<Timer>();
        ballSpawnTimer.AddTimerFinishedEventListener(HandleBallSpawnerFinishedEvent);
        StartRandomTimer();

        // get the min and max spawn location for OverlapArea
        Ball tempBall = Instantiate<Ball>(ball);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float boxColliderHalfWidth = collider.size.x / 2;
        float boxColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - boxColliderHalfWidth,
            tempBall.transform.position.y - boxColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + boxColliderHalfWidth,
            tempBall.transform.position.y + boxColliderHalfHeight);

        EventManager.AddReduceBallsEventListener(SpawnBall);
        EventManager.AddBallDiedEventListener(SpawnBall);
    }

    private void Update()
    {
        if (retrySpawn)
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        if(Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            Instantiate(ball);
            retrySpawn = false;
        }
        else
        {
            retrySpawn = true;
        }
    }

    private void StartRandomTimer()
    {
        float randomTime = Random.Range(ConfigurationUtils.MinSpawnTime, ConfigurationUtils.MaxSpawnTime);

        ballSpawnTimer.Duration = randomTime;
        ballSpawnTimer.Run();
    }

    void HandleBallSpawnerFinishedEvent()
    {
        SpawnBall();
        StartRandomTimer();
        retrySpawn = false;
    }
}
