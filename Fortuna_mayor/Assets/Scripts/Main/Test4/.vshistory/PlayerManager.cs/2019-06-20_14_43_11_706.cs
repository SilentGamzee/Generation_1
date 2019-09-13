﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class PlayerManager:MonoBehaviour
    {
        public int startPoints;
        public int pointsWin;
        public int pointsLose;
        public Text winTextPoints;

    
        public Text pointsText;
       
        public Text winText;

        private static int points;
        private static int round;
        private static bool prestart = true;

        private static PlayerManager _instance;

        public static int Points
        {
            get => points;
            set
            {
                points = value;
                
                _instance.pointsText.text = "$ " + value+".00";
            }
        }

        public static int Round
        {
            get => round;
            set
            {
                round = value;
               // _instance.roundText.text = "Round: " + value;
            }
        }

        void Start()
        {
            _instance = this;
            Reset();
        }

        public static void Reset()
        {
            Points = _instance.startPoints;
            Round = 0;
            _instance.winText.gameObject.SetActive(false);
            _instance.winTextPoints.text = "$ 0.00";
        }

        public static void Lose()
        {
            prestart = false;
            Points -= _instance.pointsLose;
            if (!IsEnoughPoints())
                PauseMenuManager.OpenPause(true);

            _instance.winText.text = "LOSE";
        }

        public static void Win()
        {
            prestart = false;
            _instance.winTextPoints.text = "$ " + _instance.pointsWin + ".00";
            Points += _instance.pointsWin;
            _instance.winText.text = "WIN";
        }

        public static bool IsEnoughPoints()
        {
            return Points >= _instance.pointsLose;
        }


    
        

        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart
                || GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart)
            {
                winText.gameObject.SetActive(false);
                return;
            }
            if(!prestart)
                winText.gameObject.SetActive(true);
        }
    }
}