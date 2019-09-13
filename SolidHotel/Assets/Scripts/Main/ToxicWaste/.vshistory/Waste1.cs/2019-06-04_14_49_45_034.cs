using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Main.ToxicWaste
{
    class Waste1:MonoBehaviour
    {
        public int ASD = 3;
        void Start()
        {
            ASD = 4;
        }
        
        void Update()
        {
            ASD++;
            if (ASD > 10)
                ASD = 0;
        }
    }
}
