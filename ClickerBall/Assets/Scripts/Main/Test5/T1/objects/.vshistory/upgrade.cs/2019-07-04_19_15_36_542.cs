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

                cost_text.text = value + " Balls";
            }
        }

        public Text cost_text;
        private int upgradeCost1;
    }
}
