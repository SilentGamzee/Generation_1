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

        private IEnumerator UpdateImageLine()
        {
            yield return new WaitForSeconds(1f);
        }


        private static float t = 0;
        void Update()
        {

            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving)
                return;

            t += Time.deltaTime;

            if (t < TimeDelay) return;
            t = 0;


        }

    }
}
