using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button start;
    public Button exit;

    void Start()
    {
        start.onClick.AddListener(OnStart);
        exit.onClick.AddListener(OnExit);
    }

    void OnStart()
    {
        this.gameObject.SetActive(false);
    }

    void OnExit()
    {
        Application.Quit();
    }
}
