﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class PreEndCalculator : MonoBehaviour
    {
        public Sprite fill;

        private static int points;
        private static Dictionary<int, bool> validRows = new Dictionary<int, bool>();

        void CalcSecondary()
        {
            points = 0;
            var rows = InitScript._instance.gameRows;
            foreach (var row in rows)
            {
                var trans = row.transform;
                var valid = true;
                int last = -1;
                for (var i = 0; i < trans.childCount; i++)
                {
                    var item = trans.GetChild(i);
                    var child = item.GetChild(0);
                    var num = child.GetComponent<ItemInfo>().num;
                    if (last == -1)
                    {
                        last = num;
                        continue;
                    }
                    if (last != num)
                        valid = false;
                }
                var index = rows.IndexOf(row);
                if (!validRows.ContainsKey(index))
                    validRows.Add(index, valid);
                else
                    validRows[index] = valid;

                if (!valid) continue;
                for (var i = 0; i < trans.childCount; i++)
                {
                    var item = trans.GetChild(i);
                    item.GetComponent<Image>().sprite = fill;
                }
                points += 100;
            }
        }

        bool IsValidRow(GameObject row)
        {
            var rows = InitScript._instance.gameRows;
            return validRows.ContainsKey(rows.IndexOf(row));
        }

        void CalculateMain()
        {
            bool valid = true;
            int lastNum = -1;
            var rows = InitScript._instance.gameRows;
            foreach (var row in rows)
            {
                var item = row.transform.GetChild(1);
                var num = item.GetChild(0).GetComponent<ItemInfo>().num;
                if (lastNum == -1) lastNum = num;
                if (IsValidRow(row)) continue;
                if (num != lastNum) valid = false;
            }

            if (!valid) return;
            foreach (var row in rows)
            {
                var item = row.transform.GetChild(1);
                item.GetComponent<Image>().sprite = fill;
            }
        }

        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.PreEnd) return;
            CalcSecondary();
            CalculateMain();
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
        }
    }
}
