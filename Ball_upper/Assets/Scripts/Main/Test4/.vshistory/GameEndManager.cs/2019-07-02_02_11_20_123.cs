using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using Test1;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    public GameObject missText;
    void Start()
    {

    }
    private static void UpdateWinner()
    {

        var points = MoveCoordinator.P;

       
        MoveCoordinator.ResetPosition();
        
        


    }

    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;

        UpdateWinner();
        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}
