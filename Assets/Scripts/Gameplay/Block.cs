using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// controls behavior of blocks
/// </summary>
public class Block : MonoBehaviour
{

    protected int pointValue;
    AddPointsEvent AddPointsEvent;

    BlockDestroyed blockDestroyed;

    virtual protected void Start()
    {
        AddPointsEvent = new AddPointsEvent();
        EventManager.AddPointsEventInvoker(this);

        blockDestroyed = new BlockDestroyed();
        EventManager.AddBlockDestroyedInvokers(this);
    }

    virtual protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            AddPointsEvent.Invoke(pointValue);
            blockDestroyed.Invoke();
            Destroy(gameObject);
        }
    }

    public void AddPointsEventListener(UnityAction<int> listener)
    {
        AddPointsEvent.AddListener(listener);
    }

    public void AddBlockDestroyedListener(UnityAction listener)
    {
        blockDestroyed.AddListener(listener);
    }
}
