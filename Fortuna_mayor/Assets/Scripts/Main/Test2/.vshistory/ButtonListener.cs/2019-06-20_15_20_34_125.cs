﻿using System;
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

        public static ButtonListener _instance;
        void Start()
        {
            PlayButton.onClick.AddListener(OnPlayButton);

            PauseButton.onClick.AddListener(OnPauseButton);
            _instance = this;
        }

        public static void OnPlayButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;
            // _instance.PlayButton.gameObject.SetActive(false);
            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            PlayerManager.Round++;
            PlayerManager.ResetWinPoints();
            GameEndManager._winnerImg.SetActive(false);

        }



        public static void OnPauseButton()
        {
            if (GameCoordinator.GetGameState() == GameCoordinator.GameStates.Lose) return;
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Pause)
                PauseMenuManager.OpenPause(false);
            else
                PauseMenuManager.Unpause();
        }
    }
}