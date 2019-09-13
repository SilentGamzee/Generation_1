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
    }

    void OnStart()
    {
        this.gameObject.SetActive(false);
    }
}
