using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectsUtils
{
    /// <summary>
    /// returns true if speedup effect is activated
    /// </summary>
    public static bool SpeedUpEffectActivated
    {
        get { return Camera.main.GetComponent<SpeedupEffectMonitor>().SpeedupEffectActivated; }
    }

    /// <summary>
    /// returns how long the speedup effect has left
    /// </summary>
    public static float SpeedupEffectSecondsLeft
    {
        get { return Camera.main.GetComponent<SpeedupEffectMonitor>().SpeedupEffectSecondsLeft; }
    }

    /// <summary>
    /// returns the factor by which the speedup effect is sped up
    /// </summary>
    public static float SpeedUpFactor
    {
        get { return Camera.main.GetComponent<SpeedupEffectMonitor>().SpeedUpFactor; }
    }
}
