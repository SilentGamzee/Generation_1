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
        private int upgradeCost1;

        void Awake()
        {
            upgradeCost = startCost;
            this.gameObject.GetComponent<Button>().interactable = false;
        }

        public void SetInteractable(bool isActive)

    }
}
