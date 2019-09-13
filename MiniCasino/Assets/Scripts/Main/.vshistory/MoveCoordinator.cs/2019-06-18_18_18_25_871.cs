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
            {
               if(GameCoordinator.GetGameState()!=GameCoordinator.GameStates.Pause)
                {
                    t = 0;
                   
                }
                        
                return;
            }
            t += Time.deltaTime;

            return;

            float param = Mathf.InverseLerp(0, 1, TimeDelay/t/5f);

            float step = MoveSpeed * param * Time.deltaTime;
            var trans = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);
                var move_x = x_points[objPoints[item.gameObject]];
                var r_pos = item.position;
                item.position = Vector3.MoveTowards(r_pos, new Vector3(move_x, r_pos.y, r_pos.z), step);

                if (Math.Abs(r_pos.x - move_x) <= 0.1f)
                {
                    if (t < TimeDelay)
                        UpdatePosition(item.gameObject);
                    else
                        GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);


                    // else
                    //     PostUpdate();

                    /*
                    if (x == row_count)
                        
                    else
                        GameCoordinator.UpdateState(GameCoordinator.GameStates.Randoming);
                        
                }
            }
        }

    }
}
