﻿using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    private static void UpdateWinner()
    {
        var list = InitScript._instance.rowList;
        var f1 = list[0];
        var f2 = list[1];
        var f3 = list[2];


    }

    private static bool IsRowFilled(Transform row)
    {
       
        var last = -1;
        for (var i = 0; i < row.childCount; i++)
        {
            var item = row.GetChild(i);
            var n = item.GetComponent<ItemInfo>().num;
            if (last == -1)
                last = n;
            else if (last == n)
                continue;
            else
                return false;
        }

        return false;
    }

    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;

        UpdateWinner();
        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}