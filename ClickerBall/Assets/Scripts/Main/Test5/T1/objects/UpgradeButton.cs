using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main.Test5.T1.objects
{
    public class UpgradeButton : MonoBehaviour
    {
        public int upgradeCost { get => upgradeCost1; set
            {
                upgradeCost1 = value;

                cost_text.text = value + " balls";
            }
        }

        public Text cost_text;
        public int startCost;
        public int ball_per_sec;
        public int click_ball_bonus;
        public int image_number;
        private int upgradeCost1;

        private int counter = 0;
        void Awake()
        {
            upgradeCost = startCost;
            SetInteractable(false);
            this.gameObject.GetComponent<Button>().onClick.AddListener(OnUpgrade);
        }

        public void SetInteractable(bool isActive)
        {
            this.gameObject.GetComponent<Button>().interactable = isActive;
        }

        void OnUpgrade()
        {
            Debug.Log("Upgrade");
            ButtonListener.per_sec_bonus += ball_per_sec;
            ButtonListener.per_click_bonus += click_ball_bonus;
            counter++;
            var last_cost = upgradeCost;

            if (click_ball_bonus > 0)
                InitScript.UpdateImage(InitScript._instance.randomCol.transform.GetChild(0).gameObject, image_number);
            
           
            upgradeCost = (int)(startCost + startCost / 10f * (float)counter);
            MoveCoordinator.P -= last_cost;
        }

    }
}
