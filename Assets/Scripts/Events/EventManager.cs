using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event manager
/// </summary>
public static class EventManager
{
    // FreezeEffectActivated support
    static List<PickUpBlock> freezeEffectInvokers = new List<PickUpBlock>();
    static List<UnityAction<float>> freezeEffectListeners = new List<UnityAction<float>>();

    static List<PickUpBlock> speedUpEffectInvokers = new List<PickUpBlock>();
    static List<UnityAction<float, float>> speedUpEffectListeners = new List<UnityAction<float, float>>();

    static List<Block> addPointsEventInvokers = new List<Block>();
    static List<UnityAction<int>> addPointsEventListeners = new List<UnityAction<int>>();

    static List<Ball> reduceBallsEventInvokers = new List<Ball>();
    static List<UnityAction> reduceBallsEventListeners = new List<UnityAction>();

    static List<Ball> ballDiedEventInvokers = new List<Ball>();
    static List<UnityAction> ballDiedEventListeners = new List<UnityAction>();

    #region methods
    /// <summary>
    /// Adds the given script as a freezer effect invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddFreezerEffectInvoker(PickUpBlock invoker)
    {
        freezeEffectInvokers.Add(invoker);
        foreach(UnityAction<float> listener in freezeEffectListeners)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a freezer effect listener
    /// </summary>
    /// <param name="listener"></param>
    public static void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezeEffectListeners.Add(listener);
        foreach(PickUpBlock invoker in freezeEffectInvokers)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a speedup effect invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddSpeedUpEffectInvoker(PickUpBlock invoker)
    {
        speedUpEffectInvokers.Add(invoker);
        foreach(UnityAction<float, float> listener in speedUpEffectListeners)
        {
            invoker.AddSpeedUpEffectListener(listener);
        } 
    }

    /// <summary>
    /// Adds the given method as a speedup effect listener
    /// </summary>
    /// <param name="listener"></param>
    public static void AddSpeedUpEffectListener(UnityAction<float, float> listener)
    {
        speedUpEffectListeners.Add(listener);
        foreach(PickUpBlock invoker in speedUpEffectInvokers)
        {
            invoker.AddSpeedUpEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a points added invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddPointsEventInvoker(Block invoker)
    {
        addPointsEventInvokers.Add(invoker);
        foreach(UnityAction<int> listener in addPointsEventListeners)
        {
            invoker.AddPointsEventListener(listener);
        }
    }

    /// <summary>
    /// adds the given method as a points added listener
    /// </summary>
    /// <param name="listener"></param>
    public static void AddPointsEventListener(UnityAction<int> listener)
    {
        addPointsEventListeners.Add(listener);
        foreach(Block invoker in addPointsEventInvokers)
        {
            invoker.AddPointsEventListener(listener);
        }
    }

    public static void AddReduceBallsEventInvoker(Ball invoker)
    {
        reduceBallsEventInvokers.Add(invoker);
        foreach(UnityAction listener in reduceBallsEventListeners)
        {
            invoker.AddReduceBallsEventListener(listener);
        }
    }

    public static void AddReduceBallsEventListener(UnityAction listener)
    {
        reduceBallsEventListeners.Add(listener);
        foreach(Ball invoker in reduceBallsEventInvokers)
        {
            invoker.AddReduceBallsEventListener(listener);
        }
    }

    public static void AddBallDiedEventInvoker(Ball invoker)
    {
        ballDiedEventInvokers.Add(invoker);
        foreach(UnityAction listner in ballDiedEventListeners)
        {
            invoker.AddReduceBallsEventListener(listner);
        }
    }

    public static void AddBallDiedEventListener(UnityAction listner)
    {
        ballDiedEventListeners.Add(listner);
        foreach(Ball invoker in ballDiedEventInvokers)
        {
            invoker.AddReduceBallsEventListener(listner);
        }
    }
    #endregion
}
