using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            counter++;
            MoveCoordinator -= upgradeCost;
            upgradeCost = (int)(startCost + startCost / 10f * (float)counter);
        }

    }
}
