using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button pauseButton;
    public Button un_pauseButton;
    public Button retryButton;
    public Button exitButton;

    public static bool PAUSED = false;
    
    void Start()
    {
        un_pauseButton.gameObject.SetActive(false);
        retryButton.onClick.AddListener(OnRetry);
        exitButton.onClick.AddListener(OnExit);
        pauseButton.onClick.AddListener(OnPause);
        un_pauseButton.onClick.AddListener(OnUnPause);
    }

    public void OnPause()
    {
        if (PlayerMechanic._LOSE) return;
        PAUSED = true;
        PlayerMechanic._pauseMenu.SetActive(true);
        un_pauseButton.gameObject.SetActive(true);
    }

    public void OnUnPause()
    {
        PAUSED = false;
        PlayerMechanic._pauseMenu.SetActive(false);
        un_pauseButton.gameObject.SetActive(false);
    }

    public void OnRetry()
    {
        PlayerMechanic.OnRetry();
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
