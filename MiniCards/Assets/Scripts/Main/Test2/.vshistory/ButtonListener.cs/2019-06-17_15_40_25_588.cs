using System;
using System.Collections;
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
        public Text lifeText;


        public int last_clicked = -1;
        public static int life_count = 1;

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
            _instance.last_clicked = -1;
            MoveCoordinator.P = 0;
            opened = 0;
            life_count = 1;
            _instance.lifeText.text = "Life: " + life_count;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            PlayerManager.Round++;

            InitScript._instance.randomCol.transform.GetChild(0).gameObject.SetActive(true);

            _instance.StartButton.gameObject.SetActive(false);
        }


        private static int opened = 0;
        private static IEnumerator OnWin()
        {
            MoveCoordinator.P++;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
            yield return new WaitForSeconds(1f);
            _instance.last_clicked = -1;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            if(opened==8)
            {
                InitScript.HideImages();
                InitScript.UpdateImages();
            }
        }

        

        public static void OnCardClick(GameObject card)
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
            InitScript.ShowImage(card);
            opened++;
            if (_instance.last_clicked == -1)
                _instance.last_clicked = card.GetComponent<ItemInfo>().num;
            else
            {
                var n = card.GetComponent<ItemInfo>().num;
                if (n != _instance.last_clicked)
                    PlayerManager.Lose();
                else
                    _instance.StartCoroutine(OnWin());


                

            }
        }




        public static void OnPauseButton()
        {
            if ((GameCoordinator.GetGameState() == GameCoordinator.GameStates.Lose)
                || (GameCoordinator.GetGameState() == GameCoordinator.GameStates.Pause)) return;
            PauseMenuManager.OpenPause(false);
        }
    }
}
