﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class PauseMenuManager:MonoBehaviour
    {
        //PUBLIC EDITOR
        public GameObject pauseMenu;
        public Button retryButton;
        public Button exitButton;
        public Text pauseText;

        //PRIVATE STATIC
        private static PauseMenuManager _instance;
        private static GameCoordinator.GameStates lastState;

        void Start()
        {
            _instance = this;

           
            retryButton.onClick.AddListener(OnRetryButton);
            exitButton.onClick.AddListener(OnExitButton);
        }

        public static void OpenPause(bool isLose)
        {
            lastState = GameCoordinator.GetGameState();
            GameCoordinator.UpdateState(GameCoordinator.GameStates.Pause);
            _instance.pauseMenu.SetActive(true);

        }


        public static void Unpause()
        {
            GameCoordinator.UpdateState(lastState);
            _instance.pauseMenu.SetActive(false);
        }

        private static void OnRetryButton()
        {
            PlayerManager.Reset();

            _instance.pauseMenu.SetActive(false);
            
            GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
        }

        private static void OnExitButton()
        {
            Application.Quit();
        }


    }
}