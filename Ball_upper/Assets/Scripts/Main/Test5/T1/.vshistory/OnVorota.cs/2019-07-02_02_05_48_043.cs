using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1;
using UnityEngine;

namespace Assets.Scripts.Main.Test5.T1
{
    public class OnVorota:MonoBehaviour
    {
        public GameObject blood;

        private float t = 0;
        void OnCollisionEnter2D(Collision2D col)
        {
           
            if (col.gameObject.tag != "GameBall") return;
            MoveCoordinator.P++;
            MoveCoordinator.ResetPosition();
            GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
            t = 3f;
            blood.SetActive(true);
        }

        void Update()
        {
            if(t>0)
            {
                t -= Time.deltaTime;
                if(t<=0)
                    blood.SetActive(false);
            }
        }
    }
}
