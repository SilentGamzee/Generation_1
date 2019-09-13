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
        

        void Update()
        {
            var rot = sunrays.transform.rotation;

            rot.z += Time.deltaTime;
            if (rot.z >= 170f)
                rot.z = 0;
            sunrays.transform.rotation = rot;
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
            
        }
    }
}
