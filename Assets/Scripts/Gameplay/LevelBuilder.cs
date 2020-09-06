using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject paddle;

    [SerializeField]
    GameObject standardBlock;
    [SerializeField]
    GameObject bonusBlock;
    [SerializeField]
    GameObject pickUpBlock;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(paddle);

        GameObject tempBlock = Instantiate<GameObject>(standardBlock);
        float BlockWidth = tempBlock.GetComponent<BoxCollider2D>().size.x * tempBlock.GetComponent<Transform>().localScale.x;
        float BlockHeight = tempBlock.GetComponent<BoxCollider2D>().size.y * tempBlock.GetComponent<Transform>().localScale.y;
        Destroy(tempBlock);

        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;

        int numBlocksPerRow = (int)(screenWidth / BlockWidth);
        float totalBlockWidth = numBlocksPerRow * BlockWidth;

        // where to start building blocks
        float topOffset = ScreenUtils.ScreenTop - screenHeight / 5 - BlockHeight / 2;
        float leftOffset = ScreenUtils.ScreenLeft + (screenWidth - totalBlockWidth) / 2 + BlockWidth / 2;

        Vector2 position = new Vector2(leftOffset, topOffset);
        for(int row = 0; row < 3; row++)
        {
            for (int col = 0; col < numBlocksPerRow; col++)
            {
                PlaceBlock(position);
                position.x += BlockWidth;
            }

            position.x = leftOffset;
            position.y += BlockHeight;
        }    
    }

    void PlaceBlock(Vector2 position)
    {
        float randomBlockType = Random.value;
        
        if (randomBlockType < ConfigurationUtils.StandardBlockProbability)
        {
            Instantiate(standardBlock, position, Quaternion.identity);
        }
        else if(randomBlockType < ConfigurationUtils.StandardBlockProbability + ConfigurationUtils.BonusBlockProbability)
        {
            Instantiate(bonusBlock, position, Quaternion.identity);
        }
        else
        {
            GameObject pickUpBlockObject = Instantiate(pickUpBlock, position, Quaternion.identity);
            PickUpBlock pickUpBlockScript = pickUpBlockObject.GetComponent<PickUpBlock>();

            float threshold = 
                ConfigurationUtils.StandardBlockProbability + ConfigurationUtils.BonusBlockProbability + ConfigurationUtils.FreezeBlockProbability;
            if(randomBlockType < threshold)
            {
                pickUpBlockScript.Effect = PickupEffect.Freezer;
            }
            else
            {
                pickUpBlockScript.Effect = PickupEffect.Speedup;
            }
        }
    }
}
