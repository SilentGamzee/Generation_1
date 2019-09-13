using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.ToxicWaste.Waste2
{
    class Waste2_sc:MonoBehaviour
    {
        public int F = 3;
        public bool IsCorner = true;
        public bool IsLogCorner = false;

        private static bool IsGood = false;

        void Start()
        {
            CallWaste();
        }

        public static void CallWaste()
        {
            IsGood = true;
            IsLogCorner = true;
        }

        void Update()
        {
            IsGood = false;
            F = 4;
            IsLogCorner = false;
        }
    }
}
