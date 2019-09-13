using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class MoveCoordinator : MonoBehaviour
    {
        //PUBLIC EDITOR
        public float MoveSpeed;
        public float TimeDelay;

        

        public static void Init()
        {

        }
        int y = 0;
        private void UpdateImageLine()
        {
            var row = InitScript._instance.rowList[y].transform;
            for(var i = 0; i < row.childCount; i++)
                InitScript.UpdateImage(row.GetChild(i).gameObject);
            yield return new WaitForSeconds(1f);
            y++;
            if (y > 2) y = 0;
        }

        private static float g = 0;
        private static float t = 0;
        void Update()
        {

            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving)
                return;

            t += Time.deltaTime;
            g += Time.deltaTime;
            if (g >= 1)
            {
                g = 0;
                UpdateImageLine();
            }
            
            if (t < TimeDelay) return;
            t = 0;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);

        }

    }
}
