using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using Test1;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
   

    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;

    }
}
