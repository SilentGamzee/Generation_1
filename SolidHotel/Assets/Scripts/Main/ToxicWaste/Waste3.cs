using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.ToxicWaste
{
    class Waste3:MonoBehaviour
    {
        public float x_coord;

        public static bool isGood = false;
        void Start()
        {
            x_coord = 5;
            CallWaste(x_coord);
        }

        public static void CallWaste(float x)
        {
            isGood = true;
        }

        void Update()
        {

            isGood = false;
            x_coord--;
            if (x_coord == 0)
                x_coord = 5;
        }
    }
}
