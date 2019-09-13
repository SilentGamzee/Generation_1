using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageClickScript : MonoBehaviour
{
    public int NumInRow { get; private set; }
    public static bool IsGameEnded = true;
    public void Init(int num)
    {
        NumInRow = num;
    }

    void Start()
    {
        var button =  this.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    
    public void OnClick()
    {
        if (ShuffleScript.InProgress || IsGameEnded) return;
        Debug.Log("Clicked: "+ NumInRow);
        var r_ball = Roll.r_ball;
        if (r_ball == NumInRow)
            PlayerMechanic.OnChooseRight();
        else
            PlayerMechanic.OnChooseBad();

        IsGameEnded = true;
        Roll.OnGameEnd();
    }
}
