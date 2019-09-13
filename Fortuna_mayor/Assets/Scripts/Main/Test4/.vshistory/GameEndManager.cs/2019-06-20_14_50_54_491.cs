using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    private static void UpdateWinner()
    {



        var objP = MoveCoordinator.objPoints_x;
        foreach (var kv in objP)
        {
            if (kv.Value != 4) continue;
            var num = kv.Key.GetComponent<ItemInfo>().num;
            if (num == 0)
                PlayerManager.Win();
            else
                PlayerManager.Lose();
        }

        ButtonListener._instance.PlayButton.gameObject.SetActive(true);
    }

    void ScaleWinner()
    {
        var t = 1.1f * Time.deltaTime;
        var objP = MoveCoordinator.objPoints_x;
        foreach (var kv in objP)
        {
            if (kv.Value != 4) continue;
            kv.Key.gameObject.transform.localScale.Scale(new Vector3(t, t, t));
        }
    }

    void ResetWinner()
    {
        var objP = MoveCoordinator.objPoints_x;
        foreach (var kv in objP)
        {
            if (kv.Value != 4) continue;
            kv.Key.gameObject.transform.localScale = Vector3.one;
        }
    }

    private float t = 0;
    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;
        if (t == 0)
            UpdateWinner();

        ScaleWinner();
        if (t < 3f) return;
        t = 0;
        ResetWinner();

        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}
