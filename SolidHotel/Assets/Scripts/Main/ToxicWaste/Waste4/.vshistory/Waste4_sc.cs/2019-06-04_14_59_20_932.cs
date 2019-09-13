using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.ToxicWaste.Waste4
{
    class Waste4_sc:MonoBehaviour
    {
        public int OREO_info = 123;

        private static float S_value = 0;
        void Start()
        {
            S_value = 5;
            OREO_info = 1;
        }

        private static void CallWaste(float v)
        {
            S_value++;
        }

        void Update()
        {
            CallWaste();
            S_value = 0;
        }
    }
}
