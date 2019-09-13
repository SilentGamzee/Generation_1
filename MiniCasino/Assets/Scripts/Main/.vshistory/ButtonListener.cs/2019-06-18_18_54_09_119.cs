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
        public Button UpButton;
        public Button DownButton;

        private static ButtonListener _instance;
        void Start()
        {
            PlayButton.onClick.AddListener(OnPlayButton);
          
            PauseButton.onClick.AddListener(OnPauseButton);
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
        
        public static void OnPauseButton()
        {
            PauseMenuManager.OpenPause(false);
        }
    }
}