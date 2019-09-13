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


        void Start()
        {
            x_coord = 5;
        }

        public static void CallWaste(int x)
        {

        }

        void Update()
        {
            x_coord--;
            if (x_coord == 0)
                x_coord = 5;
        }
    }
}
