using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// controls paddle behavior
/// </summary>
public class Paddle : MonoBehaviour
{
    Rigidbody2D rb2d;
    BoxCollider2D bc2d;

    float halfColliderWidth;
    float halfColliderHeight;

    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;

    bool frozen = false;
    Timer freezeTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();

        halfColliderHeight = bc2d.size.y / 2 * GetComponent<Transform>().localScale.x;
        halfColliderWidth = bc2d.size.x / 2 * GetComponent<Transform>().localScale.y;

        freezeTimer = gameObject.AddComponent<Timer>();
        freezeTimer.AddTimerFinishedEventListener(HandleFreezeTimer);
        EventManager.AddFreezerEffectListener(HandleFreezeEvent);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    // called on a fixed interval of 0.02 seconds
    private void FixedUpdate()
    {
        if (!frozen && Input.GetAxis("Horizontal") != 0)
        {
            Vector2 position = rb2d.position;

            // m/s * s = meters
            position.x += Input.GetAxis("Horizontal") * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;

            position.x = CalculateClampedX(position.x);
            rb2d.MovePosition(position);
        }
    }

    /// <summary>
    /// clamps the paddle to the screen
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    private float CalculateClampedX(float x)
    {
        if(x - halfColliderWidth < ScreenUtils.ScreenLeft)
        {
            x = halfColliderWidth + ScreenUtils.ScreenLeft;
        }
        else if(x + halfColliderWidth > ScreenUtils.ScreenRight)
        {
            x = ScreenUtils.ScreenRight - halfColliderWidth;
        }

        return x;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && TopCollision(coll))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    bool TopCollision(Collision2D col)
    {
        float tolerance = 0.05f;

        // there are only 2 contacts
        ContactPoint2D[] contacts = col.contacts;
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }

    void HandleFreezeEvent(float duration)
    {
        frozen = true;
        if (!freezeTimer.Running)
        {
            freezeTimer.Duration = duration;
            freezeTimer.Run();
        }
        else
        {
            freezeTimer.AddTime(duration);
        }
    }

    void HandleFreezeTimer()
    {
        frozen = false;
        freezeTimer.Stop();
    }
}


