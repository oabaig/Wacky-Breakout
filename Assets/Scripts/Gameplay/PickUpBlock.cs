using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpBlock : Block
{

    [SerializeField]
    Sprite freezeBlockSprite, speedUpBlockSprite;

    FreezerEffectActivated freezerEffectActivated;
    SpeedUpEffectActivated speedUpEffectActivated;

    PickupEffect effect;
    float duration;
    float speedUpEffectMult;

    public PickupEffect Effect
    {
        set
        {
            effect = value;

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if(effect == PickupEffect.Freezer)
            {
                spriteRenderer.sprite = freezeBlockSprite;
                freezerEffectActivated = new FreezerEffectActivated();
                EventManager.AddFreezerEffectInvoker(this);
                duration = ConfigurationUtils.FreezerBlockDuration;
            }
            else
            {
                spriteRenderer.sprite = speedUpBlockSprite;
                speedUpEffectActivated = new SpeedUpEffectActivated();
                EventManager.AddSpeedUpEffectInvoker(this);
                duration = ConfigurationUtils.SpeedUpBlockDuration;
            }
        }
    }

    // Start is called before the first frame update
    override protected void Start()
    {
        pointValue = ConfigurationUtils.PickUpBlockPoints;
        speedUpEffectMult = ConfigurationUtils.SpeedIncreaseMult;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball")){
            if (effect == PickupEffect.Freezer)
            {
                freezerEffectActivated.Invoke(duration);
            }
            else if (effect == PickupEffect.Speedup)
            {
                speedUpEffectActivated.Invoke(duration, speedUpEffectMult); 
            }
        }
        base.OnCollisionEnter2D(coll);
    }

    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectActivated.AddListener(listener);
    }

    public void AddSpeedUpEffectListener(UnityAction<float, float> listener)
    {
        speedUpEffectActivated.AddListener(listener);
    }
}
