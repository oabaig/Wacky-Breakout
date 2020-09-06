using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block
{
    // Start is called before the first frame update
    override protected void Start()
    {
        pointValue = ConfigurationUtils.BonusBlockPoints;
        base.Start();
    }
}
