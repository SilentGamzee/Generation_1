using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class MoveCoordinator : MonoBehaviour
    {
        //PUBLIC EDITOR
        public float MoveSpeed;
        public float TimeDelay;
        public Text pointsVorotaText;
        public GameObject left;
        public GameObject right;

        //PRIVATE STATIC
        private static MoveCoordinator _instance;
        private static List<Vector3> points = new List<Vector3>();
        private static Vector3 nextPoint;



        private static Vector3 start_pos;

        public static int P
        {
            get => p;
            set
            {
                p = value;
                _instance.pointsVorotaText.text = "Points: " + value;
            }
        }

        private static float t = 0;
        private static int p = 0;

        private static float korzina_y;

        void Awake()
        {
            _instance = this;
        }

        public static void Init()
        {
            
        }

      

        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;


            return;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
            
        }
    }
}
