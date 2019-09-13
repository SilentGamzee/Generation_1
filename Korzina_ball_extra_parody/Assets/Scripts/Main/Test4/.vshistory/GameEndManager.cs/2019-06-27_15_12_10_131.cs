﻿using Assets.Scripts.Main;
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
        var item = InitScript._instance.randomCol.transform.GetChild(0);
        item.GetComponent<Rigidbody2D>().simulated = false;
        item.position = Vector3.zero;
        item.localRotation = new Quaternion(0, 0, 0, 0);


        ButtonListener._instance.tapObj.SetActive(true);

        _instance.loseText.SetActive(true);

    }

    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;

        UpdateWinner();
        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}