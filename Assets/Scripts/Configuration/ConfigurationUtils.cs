using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{

    static ConfigurationData configurationData;

    #region Properties

    #region Game Properties
    /// <summary>
    /// gets how fast the paddle moves
    /// </summary>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the total balls in the game
    /// </summary>
    public static int TotalBalls
    {
        get { return configurationData.TotalBalls; }
    }
    #endregion

    #region Ball Configuration
    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    public static float BallDeathTimer
    {
        get { return configurationData.BallDeathTimer; }
    }

    public static float MinSpawnTime
    {
        get { return configurationData.MinSpawnTime; }
    }

    public static float MaxSpawnTime
    {
        get { return configurationData.MaxSpawnTime; }
    }
    #endregion

    #region Block Points
    public static int StandardBlockPoints
    {
        get { return configurationData.StandardBlockPoints; }
    }

    public static int BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints; }
    }

    public static int PickUpBlockPoints
    {
        get { return configurationData.PickUpBlockPoints; }
    }
    #endregion

    #region Block Probabilities
    public static float StandardBlockProbability
    {
        get { return configurationData.StandardBlockProbability; }
    }

    public static float BonusBlockProbability
    {
        get { return configurationData.BonusBlockProbability; }
    }

    public static float FreezeBlockProbability
    {
        get { return configurationData.FreezeBlockProbability; }
    }

    public static float SpeedupBlockProbability
    {
        get { return configurationData.SpeedupBlockProbability; }
    }
    #endregion

    #region Block Properties

    /// <summary>
    /// speed increase multiplier for fast block
    /// </summary>
    public static float SpeedIncreaseMult
    {
        get { return configurationData.SpeedIncreaseMult; }
    }

    /// <summary>
    /// speed decrease multiplier for slow block;
    /// </summary>
    public static float SpeedDecreaseMult
    {
        get { return configurationData.SpeedDecreaseMult; }
    }

    /// <summary>
    /// duration for freeze block
    /// </summary>
    public static float FreezerBlockDuration
    {
        get { return configurationData.FreezerBlockDuration; }
    }

    public static float SpeedUpBlockDuration
    {
        get { return configurationData.SpeedUpBlockDuration; }
    }
    #endregion

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
