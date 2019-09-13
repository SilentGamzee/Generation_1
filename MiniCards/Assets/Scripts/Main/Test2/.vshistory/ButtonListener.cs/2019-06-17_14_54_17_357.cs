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

        public Button PauseButton;
        public Button StartButton;


        private static int last_clicked = -1;

        public static ButtonListener _instance;
        void Start()
        {
            var trans = InitScript._instance.randomCol.transform.GetChild(0);
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i).gameObject;
                trans.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate { OnCardClick(item); });
            }


            PauseButton.onClick.AddListener(OnPauseButton);
            StartButton.onClick.AddListener(OnStartButton);
            _instance = this;
        }

        public static void OnStartButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;
            last_clicked = -1;
            MoveCoordinator.P = 0;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            PlayerManager.Round++;

            InitScript._instance.randomCol.transform.GetChild(0).gameObject.SetActive(true);

            _instance.StartButton.gameObject.SetActive(false);
        }



        public static void OnCardClick(GameObject card)
        {
            InitScript.ShowImage(card);
            if (last_clicked == -1)
                last_clicked = card.GetComponent<ItemInfo>().num;

        }




        public static void OnPauseButton()
        {
            PauseMenuManager.OpenPause(false);
        }
    }
}
