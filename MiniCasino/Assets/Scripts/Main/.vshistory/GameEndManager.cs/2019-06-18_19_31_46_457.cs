using Assets.Scripts.Main;
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

        var c = 0;
        for (var i = 0; i < 3; i++)
        {
            var row = list[i].transform;
            if (IsRowFilled(row))
            {
                c++;
                for (var j = 0; j < row.childCount - 1; j++)
                {
                    var item = row.GetChild(i);
                    var next = row.GetChild(i + 1);
                    LineGenerator.GenerateLine(item.position, next.position);
                }
            }
        }

        for (var j = 0; j < f1.transform.childCount - 1; j++)
        {
            var c1 = f1.transform.GetChild(j);
            var c2 = f2.transform.GetChild(j);
            var c3 = f3.transform.GetChild(j);

            var n1 = c1.GetComponent<ItemInfo>().num;
            var n2 = c2.GetComponent<ItemInfo>().num;
            var n3 = c3.GetComponent<ItemInfo>().num;

            if (n1 == n2 && n2==n3)
            {
                c+=3;
                LineGenerator.GenerateLine(c1.position, c2.position);
                LineGenerator.GenerateLine(c2.position, c3.position);
            }
        }
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

        return true;
    }

    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;

        UpdateWinner();
        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}
