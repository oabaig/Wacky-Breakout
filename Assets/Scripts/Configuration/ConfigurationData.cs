using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10f;
    static int totalBalls = 5;

    static float ballImpulseForce = 200f;
    static float ballLifeTime = 10f;
    static float minSpawnTime = 5f; // minimum time that it takes for the ball to spawn 
    static float maxSpawnTime = 10f; // maximum time that it takes for the ball to spawn

    static int standardBlockPoints = 1;
    static int bonusBlockPoints = 5;
    static int pickupBlockPoints = 2;

    // probabilities for each block to spawn
    static float standardBlockProbability = 0.6f;
    static float bonusBlockProbability = 0.1f;
    static float freezeBlockProbability = 0.15f;
    static float speedupBlockProbability = 0.15f;

    // fast block and slow block multipliers
    static float speedIncreaseMult = 2;
    static float speedDecreaseMult = 0.5f;

    static float freezerBlockDuration = 2f;
    static float speedUpBlockDuration = 2f;
    #endregion

    #region Properties

    #region Paddle
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the total balls in the game
    /// </summary>
    public int TotalBalls
    {
        get { return totalBalls; }
    }
    #endregion

    #region Ball
    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    /// <summary>
    /// Gets the time to destroy the ball
    /// </summary>
    /// <value>death timer</value>
    public float BallDeathTimer
    {
        get { return ballLifeTime; }
    }

    /// <summary>
    /// Gets minimum ball spawn time
    /// </summary>
    public float MinSpawnTime
    {
        get { return minSpawnTime; }
    }

    /// <summary>
    /// gets maximum ball spawn time
    /// </summary>
    public float MaxSpawnTime
    {
        get { return maxSpawnTime; }
    }
    #endregion

    #region Blocks
    #region Block Points
    public int StandardBlockPoints
    {
        get { return standardBlockPoints; }
    }

    public int BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    public int PickUpBlockPoints
    {
        get { return pickupBlockPoints; }
    }
    #endregion

    #region Block Probabilities
    /// <summary>
    /// standard block probability
    /// </summary>
    public float StandardBlockProbability
    {
        get { return standardBlockProbability; }
    }

    /// <summary>
    /// bonus block probability
    /// </summary>
    public float BonusBlockProbability
    {
        get { return bonusBlockProbability; }
    }

    /// <summary>
    /// slow block probability
    /// </summary>
    public float FreezeBlockProbability
    {
        get { return freezeBlockProbability; }
    }

    /// <summary>
    /// fast block probability
    /// </summary>
    public float SpeedupBlockProbability
    {
        get { return speedupBlockProbability; }
    }
    #endregion

    #region Block Properties
    /// <summary>
    /// speed increase multiplier for fast block
    /// </summary>
    public float SpeedIncreaseMult
    {
        get { return speedIncreaseMult; }
    }

    /// <summary>
    /// speed decrease multiplier for slow block
    /// </summary>
    public float SpeedDecreaseMult
    {
        get { return speedDecreaseMult; }
    }

    public float FreezerBlockDuration
    {
        get { return freezerBlockDuration; }
    }

    public float SpeedUpBlockDuration
    {
        get { return speedUpBlockDuration; }
    }
    #endregion
    #endregion

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        
    }

    #endregion
}
