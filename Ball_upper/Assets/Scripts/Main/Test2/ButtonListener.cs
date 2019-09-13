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
        public Button PauseButton;


        public static ButtonListener _instance;
        void Start()
        {
            PlayButton.onClick.AddListener(OnPlayButton);





            _instance = this;
        }

        public static void OnStartButton()
        {


            MoveCoordinator.P = 1;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            PlayerManager.Round++;

        }

        public static void OnPlayButton()
        {
            if (GameCoordinator.GetGameState() == GameCoordinator.GameStates.WaitingToStart)
            {
                var trans_col = InitScript._instance.randomCol.transform;
                var item = trans_col.GetChild(0);
                item.GetComponent<Rigidbody2D>().simulated = true;
                MoveCoordinator.AddForceToBall();
                GameEndManager._instance.missText.SetActive(false);
                GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            }
        }




        public static void OnPauseButton()
        {
            PauseMenuManager.OpenPause(false);
        }
    }
}
