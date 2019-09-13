using System;
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
        public int pointsLose;
        public Text pointsText;
        public Text winText;



        private static int points;
        private static int round;

        public static PlayerManager _instance;

        public static int Points
        {
            get => points;
            set
            {
                points = value;
                _instance.pointsText.text = "$ " + value + ".00";
            }
        }

        

        void Awake()
        {
            _instance = this;
            Points = startPoints;
        }

        public static void Reset()
        {
            Points = _instance.startPoints;
            
        }

        public static void Lose()
        {
            if (!IsEnoughPoints())
                PauseMenuManager.OpenPause(true);
        }

        public static void Win(int p)
        {
            var win = ButtonListener.rate * p;
            Points += _instance.pointsWin;
        }

        public static bool IsEnoughPoints()
        {
            return Points >= _instance.pointsLose;
        }

        public static void ResetWinText()
        {
            _instance.winText.text = "$ 0.00";
        }

    }
}
