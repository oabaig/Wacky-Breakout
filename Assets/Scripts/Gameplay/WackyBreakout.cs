using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WackyBreakout : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddLastBallLostListeners(HandleLastBallLostEvent);
        EventManager.AddBlockDestroyedListeners(HandleBlockDestroyedEvent);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.FindGameObjectWithTag("PauseMenu") == null)
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }

    void HandleLastBallLostEvent()
    {
        Object.Instantiate(Resources.Load("GameOver"));
    }

    void HandleBlockDestroyedEvent()
    {
        if(GameObject.FindGameObjectsWithTag("Block").Length == 1)
        {
            Object.Instantiate(Resources.Load("GameOver"));
        }
    }
}
