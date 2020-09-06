using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void HandlePlayButtonOnClickedEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void HandleQuitButtonOnClickedEvent()
    {
        Time.timeScale = 1;
        MenuManager.GoToMenu(MenuName.Main);
        Destroy(gameObject);
    }
}
