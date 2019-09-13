using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.Test5.T1
{
    public class OnKorzina:MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D col)
        {
           
            if (col.gameObject.tag != "GameBall") return;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
        }
    }
}
