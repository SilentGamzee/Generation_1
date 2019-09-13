using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using Test1;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    private static void UpdateWinner()
    {

        var points = MoveCoordinator.P;

        PlayerManager.Points += points;
        MoveCoordinator.P = 0;
        MoveCoordinator.ResetPosition();
        
        

        PauseMenuManager.OpenPause(true);

    }

    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;

        UpdateWinner();
        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}
