using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb2d;
    Timer stopTimer; // stop the ball for a while when it spawns
    Timer lifeTimer; // how long ball should stay alive
    float stopTimerTime = 1f; // how long it should stop when it spawns

    bool speedUp = false;
    Timer speedUpTimer;
    float multiplier;

    ReduceBallsEvent reduceBallsEvent;
    BallDiedEvent ballDiedEvent;

    // Start is called before the first frame update
    void Start()
    {
        multiplier = 1;

        lifeTimer = gameObject.AddComponent<Timer>();
        lifeTimer.Duration = ConfigurationUtils.BallDeathTimer;
        lifeTimer.AddTimerFinishedEventListener(TimerEventFinished);

        stopTimer = gameObject.AddComponent<Timer>();
        stopTimer.Duration = stopTimerTime;
        stopTimer.AddTimerFinishedEventListener(StopTimerEventFinished);
        stopTimer.Run();

        speedUpTimer = gameObject.AddComponent<Timer>();
        speedUpTimer.AddTimerFinishedEventListener(SpeedUpTimerEventFinished);

        EventManager.AddSpeedUpEffectListener(HandleSpeedUpEvent);

        reduceBallsEvent = new ReduceBallsEvent();
        EventManager.AddReduceBallsEventInvoker(this);

        ballDiedEvent = new BallDiedEvent();
        EventManager.AddBallDiedEventInvoker(this);
    }

    private void Update()
    {
    }

    /// <summary>
    /// sets the direction of the ball when it hits the paddle
    /// </summary>
    /// <param name="direction"></param>
    public void SetDirection(Vector2 direction)
    {
        // get the speed of the ball
        float speed = rb2d.velocity.magnitude;

        // change the direction with the current speed
        rb2d.velocity = speed * direction;
    }

    /// <summary>
    /// sets a new speed for the ball with a speed multiplier
    /// </summary>
    /// <param name="speedMultiplier"></param>
    private void MultiplySpeed(float speedMultiplier)
    {
        rb2d.velocity *= speedMultiplier;
    }

    /// <summary>
    /// Start moving the ball
    /// </summary>
    private void StartMoving()
    {
        rb2d = GetComponent<Rigidbody2D>();

        float degree = -90 * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Cos(degree), Mathf.Sin(degree));
        Vector2 force = dir * ConfigurationUtils.BallImpulseForce;

        if (EffectsUtils.SpeedUpEffectActivated)
        {
            force *= EffectsUtils.SpeedUpFactor;
            speedUpTimer.Duration = EffectsUtils.SpeedupEffectSecondsLeft;
            speedUpTimer.Run();
        }

        rb2d.AddForce(force);

        lifeTimer.Run();
    }

    /// <summary>
    /// Deletes the ball when it becomes invisible
    /// </summary>
    private void OnBecameInvisible()
    {
        if (!lifeTimer.Finished) // destroy ball if the timer is not finished
        {
            if(transform.position.y < ScreenUtils.ScreenBottom) // only destroy if the ball is below the screen
            {
                reduceBallsEvent.Invoke();
                Destroy(gameObject);
            }
        }
    }

    private void HandleSpeedUpEvent(float duration, float speedMult)
    {
        speedUp = true;
        if (!speedUpTimer.Running)
        {
            multiplier *= speedMult;
            speedUpTimer.Duration = duration;
            speedUpTimer.Run();
            gameObject.GetComponent<Rigidbody2D>().velocity *= multiplier;
        }
        else
        {
            speedUpTimer.AddTime(duration);
        }
    }

    public void AddReduceBallsEventListener(UnityAction listener)
    {
        reduceBallsEvent.AddListener(listener);
    }

    void StopTimerEventFinished()
    {
        stopTimer.Stop();
        StartMoving();
    }

    void TimerEventFinished()
    {
        ballDiedEvent.Invoke();
        Destroy(gameObject);
    }

    void SpeedUpTimerEventFinished()
    {
        speedUpTimer.Stop();
        MultiplySpeed(1 / multiplier);
        multiplier = 1;
    }
}
