using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    [SerializeField]
    Sprite block1, block2, block3;

    // Start is called before the first frame update
    override protected void Start()
    {
        pointValue = ConfigurationUtils.StandardBlockPoints;

        // choose a random block for the standard block
        int choice = Random.Range(0, 3);

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        switch (choice)
        {
            case 0: sprite.sprite = block1; break;
            case 1: sprite.sprite = block2; break;
            case 2: sprite.sprite = block3; break;
        }
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
