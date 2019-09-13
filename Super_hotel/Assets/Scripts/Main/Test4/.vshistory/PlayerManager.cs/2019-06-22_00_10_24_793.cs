using System;
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

        public Text pointsText;
        public Text win_value_text;
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
                
                
                _instance.pointsText.text = value+".00";
            }
        }

        public static void SetWin(int win_value)
        {
            _instance.win_value_text.text = win_value + ".00";
        }
      

        void Start()
        {
            _instance = this;
            Points = startPoints;

            winText.gameObject.SetActive(false);
        }

        public static void Reset()
        {
            Points = _instance.startPoints;
    
        }

        public static void Lose()
        {
            prestart = false;
            Points -= _instance.pointsLose;
            if (!IsEnoughPoints())
                PauseMenuManager.OpenPause(true);

            _instance.winText.text = "LOSE";
        }

        public static void Win(int c)
        {
            prestart = false;
            Points += _instance.pointsWin;
            SetWin(_instance.pointsWin);
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
