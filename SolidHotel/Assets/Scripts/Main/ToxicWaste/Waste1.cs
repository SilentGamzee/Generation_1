using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.ToxicWaste
{
    class Waste1:MonoBehaviour
    {
        public int ASD = 3;
        private static int WasteASD = 1;
        void Start()
        {
            ASD = 4;
            CallWaste(WasteASD+1);
        }

        public static void CallWaste(int w)
        {
            WasteASD = w;
        }
        
        void Update()
        {
            WasteASD = 0;
            ASD++;
            if (ASD > 10)
                ASD = 0;
        }
    }
}
