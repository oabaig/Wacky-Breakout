using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour
{
    Timer speedEffectTimer;
    float speedupFactor;

    /// <summary>
    /// returns whether the speed up effect is activated
    /// </summary>
    public bool SpeedupEffectActivated
    {
        get { return speedEffectTimer.Running; }
    }

    /// <summary>
    /// returns how long the speedup effect has left
    /// </summary>
    public float SpeedupEffectSecondsLeft
    {
        get { return speedEffectTimer.SecondsLeft; }
    }

    /// <summary>
    /// returns by how much the speedup effect is
    /// </summary>
    public float SpeedUpFactor
    {
        get { return speedupFactor; }
    }

    // Start is called before the first frame update
    void Start()
    {
        speedEffectTimer = gameObject.AddComponent<Timer>();
        speedEffectTimer.AddTimerFinishedEventListener(HandleSpeedupEffectTimerFinished);
        EventManager.AddSpeedUpEffectListener(HandleSpeedupEffectActivated);
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// handles the speedup effect
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="factor"></param>
    void HandleSpeedupEffectActivated(float duration, float factor)
    {
        if (!speedEffectTimer.Running)
        {
            speedupFactor = factor;
            speedEffectTimer.Duration = duration;
            speedEffectTimer.Run();
        }
        else
        {
            speedEffectTimer.AddTime(duration);
        }
    }

    void HandleSpeedupEffectTimerFinished()
    {
        speedEffectTimer.Stop();
        speedupFactor = 1;
    }
}
