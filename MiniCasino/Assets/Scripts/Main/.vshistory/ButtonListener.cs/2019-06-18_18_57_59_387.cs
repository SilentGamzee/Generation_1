using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class ButtonListener : MonoBehaviour
    {
        public Button PlayButton;
        public Button PauseButton;
        public Button UpButton;
        public Button DownButton;

        public Text rateText;

        private static ButtonListener _instance;
        private static int rate;
        void Start()
        {
            PlayButton.onClick.AddListener(OnPlayButton);
            PauseButton.onClick.AddListener(OnPauseButton);
            UpButton.onClick.AddListener(OnArrowUp);
            DownButton.onClick.AddListener(OnArrowDown);
            rate = PlayerManager._instance.pointsLose;

            _instance = this;
        }

        public static void OnPlayButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;
            
            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            PlayerManager.ResetWinText();
        }

        public static void OnArrowUp()
        {

        }

        public static void OnArrowDown()
        {
            var min = PlayerManager._instance.pointsLose;
            if()
        }

        public static void OnPauseButton()
        {
            PauseMenuManager.OpenPause(false);
        }

        private static void UpdateRateText()
        {
            _instance.rateText.text = "$ " + rate + ".00";
        }
    }
}
