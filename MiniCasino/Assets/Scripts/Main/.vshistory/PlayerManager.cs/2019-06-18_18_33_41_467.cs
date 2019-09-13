﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class PlayerManager : MonoBehaviour
    {
        public int startPoints;
        public int pointsWin;
        public int pointsLose;
        public Text pointsText;
        public Text winText;



        private static int points;
        private static int round;

        private static PlayerManager _instance;

        public static int Points
        {
            get => points;
            set
            {
                points = value;
                _instance.pointsText.text = "$ " + value + ".00";
            }
        }

        public static int Round
        {
            get => round;
            set
            {
                round = value;

            }
        }

        void Start()
        {
            _instance = this;
            Points = startPoints;
            Round = 0;
        }

        public static void Reset()
        {
            Points = _instance.startPoints;
            Round = 0;
        }

        public static void Lose()
        {
            Points -= _instance.pointsLose;
            if (!IsEnoughPoints())
                PauseMenuManager.OpenPause(true);
        }

        public static void Win()
        {
            Points += _instance.pointsWin;
        }

        public static bool IsEnoughPoints()
        {
            return Points >= _instance.pointsLose;
        }

        public static void ResetWinText()
        {
            _instance.winText.text = "$ 0.00"
        }

    }
}