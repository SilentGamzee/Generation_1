using Assets.Scripts.Main.Test5.T1.objects;
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
        private static float lastClickTime = 1f;

        private static List<UpgradeButton> upgradesList = new List<UpgradeButton>(); 

        void Start()
        {
            _instance = this;
         
            StartButton.onClick.AddListener(OnStartButton);

            var list = FindObjectsOfType<UpgradeButton>();
            foreach(var k in list)
                upgradesList.Add(k);
        }

        public static void OnStartButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart
                && GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;

            if (GameCoordinator.GetGameState() == GameCoordinator.GameStates.WaitingToStart)
            {
                MoveCoordinator.P = 0;

                PlayerManager.Round++;
                
                GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            }
            lastClickTime = 0.8f;

            MoveCoordinator.P++;

            var trans_col = InitScript._instance.randomCol.transform;
            trans_col.GetChild(0).localScale = new Vector3(lastClickTime, lastClickTime, lastClickTime);
        }


        public static void UpdateUpgrades()
        {
            upgradesList.ForEach(x => x.SetInteractable(MoveCoordinator.P >= x.upgradeCost) );
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
            MoveSunrays();

            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;

            if (lastClickTime < 1f)
            {
                var trans_col = InitScript._instance.randomCol.transform;
                
                lastClickTime += Time.deltaTime;
                if (lastClickTime > 1f)
                    lastClickTime = 1f;
                trans_col.GetChild(0).localScale = new Vector3(lastClickTime, lastClickTime, lastClickTime);
            }
        }
    }
}
