using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

        foreach(GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            Destroy(ball);
        }
    }

    public void HandleReturnToMainMenuButton()
    {
        Time.timeScale = 1;
        MenuManager.GoToMenu(MenuName.Main);
        Destroy(gameObject);
    }
}
