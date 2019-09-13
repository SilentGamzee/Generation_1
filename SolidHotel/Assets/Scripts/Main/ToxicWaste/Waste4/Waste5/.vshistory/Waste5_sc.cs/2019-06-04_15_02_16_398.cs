using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.ToxicWaste.Waste4.Waste5
{
    class Waste5_sc:MonoBehaviour
    {
        public static int f = 0;
        private static int g = 0;
        private static int j = 0;

        void Start()
        {
            f = 1;
            g = 1;
            j = 1;
        }

        public static void CallWaste(int x)
        {
            f = x;
            g = x;
            j = x;
        }

        private static float t = 0;
        void Update()
        {
            t++;
            if (t > 10) t = 0;
            CallWaste(t);
        }

    }
}
