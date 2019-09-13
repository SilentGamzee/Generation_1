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
    class ButtonListener : MonoBehaviour
    {
        public Button PlayButton;
        public Button PauseButton;
        public Button StartButton;

        public Transform top;
        public Transform bottom;

        public Image sunrays;
        public Image sunrays_2;

        
        public static ButtonListener _instance;


        void Start()
        {
            _instance = this;
         
            StartButton.onClick.AddListener(OnStartButton);

        }

        public static void OnStartButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart
                && GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;

            if (GameCoordinator.GetGameState() == GameCoordinator.GameStates.WaitingToStart)
            {
                MoveCoordinator.P = 0;

                PlayerManager.Round++;
                var trans_col = InitScript._instance.randomCol.transform;
                var item = trans_col.GetChild(0);
                item.GetComponent<Rigidbody2D>().simulated = true;

                GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            }
       

            MoveCoordinator.P++;
            
        }

       

        public static void ResetStats()
        {
           
        }

        private float t = 0;
        private bool sunray_forward = true;

        void MoveSunrays()
        {
            var m = Time.deltaTime / 5f;
            var rot = sunrays.transform.rotation;
           
            if (rot.z >= 0.9f)
                sunray_forward = false;
            else if (rot.z <= 0.1f)
                sunray_forward = true;

            if (!sunray_forward)
                m *= -1;
            rot.z += m;

            sunrays.transform.rotation = rot;
        }

        void Update()
        {
            

            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
            
        }
    }
}
