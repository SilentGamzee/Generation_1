using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main
{
    class RollingImages:MonoBehaviour
    {
        public float RollingTime;
        public float RerollTime;

        private static float rerollT = 0;
        private static float timeToEnd = 0;
        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Randoming) return;
            
            timeToEnd += Time.deltaTime;
            if (timeToEnd >= RollingTime)
            {
                timeToEnd = 0;
                GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
                return;
            }

            rerollT += Time.deltaTime;
            if (rerollT >= RerollTime)
            {
                rerollT = 0;
                InitScript.UpdateImages();
            }
        }
    }
}
