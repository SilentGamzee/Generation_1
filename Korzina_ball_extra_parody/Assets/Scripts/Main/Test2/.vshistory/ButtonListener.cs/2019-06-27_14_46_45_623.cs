using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class ButtonListener : MonoBehaviour
    {
        public Button PlayButton;
        public GameObject tapObj;

        public static ButtonListener _instance;
        void Start()
        {
            PlayButton.onClick.AddListener(OnPlayButton);


          
            _instance = this;
        }

        public static bool OnStartButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;


            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            PlayerManager.Round++;

            var trans_col = InitScript._instance.randomCol.transform;
            var item = trans_col.GetChild(0);
            item.GetComponent<Rigidbody2D>().simulated = true;
            MoveCoordinator.AddForceToBall();
            _instance.tapObj.SetActive(false);
        }

        public static void OnPlayButton()
        {
            
            OnStartButton();
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
           
            MoveCoordinator.AddForceToBall();




        }



    }
}
