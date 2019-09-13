using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class PlayerMechanic : MonoBehaviour
    {
        public Text points_text;
        public Text spent_text;
        public Text round_text;

        public GameObject pauseMenu;
        public int pointsPerGame;
        public int pointsInStart;


        private static int POINTS
        {
            get => pOINTS;
            set
            {
                pOINTS = value;
                if (value <= 0 && !_LOSE) Lose();

                UpdatePoints(value);
            }
        }
        private static Text _points_text;
        private static Text _spent_text;
        private static Text _round_text;
        private static int _pointsInStart;
        private static int pOINTS = 0;

       

        public static int SPENT_COUNTER
        {
            get => sPENT_COUNTER;
            set
            {
                sPENT_COUNTER = value;
                _spent_text.text = "Spent: " + value;
            }
        }
        public static int ROUND_COUNTER {
            get => rOUND_COUNTER;
            set
            {
                rOUND_COUNTER = value;
                _round_text.text = "Round: " + value;
            }
        }

        public static int _pointsPerGame;
        public static GameObject _pauseMenu;

        public static bool _LOSE = false;
        private static int sPENT_COUNTER;
        private static int rOUND_COUNTER;

        void Start()
        {
            _points_text = points_text;
            _spent_text = spent_text;
            _round_text = round_text;
            _pointsPerGame = pointsPerGame;
            _pointsInStart = pointsInStart;
            POINTS = pointsInStart;
            _pauseMenu = pauseMenu;
        }

        public static void Lose()
        {
            _pauseMenu.SetActive(true);
            _LOSE = true;
            POINTS = 0;
        }

        public static void OnRetry()
        {
            POINTS = 0;
            SPENT_COUNTER = 0;
            ROUND_COUNTER = 0;
            _LOSE = false;
            _pauseMenu.SetActive(false);
            POINTS = _pointsInStart;

            ImageClickScript.IsGameEnded = true;
            Roll._LAUNCH_GAME = false;
            ShuffleScript.InProgress = false;
            ShuffleScript.Test_shuffle = true;
            Roll._waiter.SetActive(false);
        }

        private static void UpdatePoints(int count) => _points_text.text = "Points: " + POINTS;

        public static void OnChooseRight() => POINTS += _pointsPerGame;
        
        public static void OnChooseBad()
        {
            POINTS -= _pointsPerGame;
            PlayerMechanic.SPENT_COUNTER += PlayerMechanic._pointsPerGame;
        }
    }
}
