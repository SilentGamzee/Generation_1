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
        void OnCollisionEnter2D(Collision2D col)
        {
           
            if (col.gameObject.tag != "GameBall") return;
            MoveCoordinator.P++;
            var item = InitScript._instance.randomCol.transform.GetChild(0);
            item.GetComponent<Rigidbody2D>().simulated = false;
            item.position = Vector3.zero;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
        }
    }
}
