using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class MoveCoordinator : MonoBehaviour
    {
        //PUBLIC EDITOR
        public float MoveSpeed;
        public float TimeDelay;

        //PRIVATE STATIC
        private static List<float> x_points = new List<float>();
        

        private static float start_x;
        private static int x = 0;
        private static float delay = 0;
        private static int row_count = 0;

        //PUBLIC STATIC
        public static Dictionary<GameObject, int> objPoints = new Dictionary<GameObject, int>();

        public static void Init()
        {
            
        }



       
        private static float t = 0;
        void Update()
        {

            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving)
                return;
            
            t += Time.deltaTime;

            if (t < TimeDelay) return;
            t = 0;

        }

    }
}
