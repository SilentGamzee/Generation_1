using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main
{
    class ShuffleScript: MonoBehaviour
    {
        //PUBLIC
        public float shuffle_speed = 1f;

        //PUBLIC STATIC
        public static bool InProgress = false;

        //CONST
        public const float shuffle_time = 6f;

        //PRIVATE STATIC
        private static float progress = 100f;
        private static Dictionary<GameObject, Vector3> shuffle_point = new Dictionary<GameObject, Vector3>();
        private static List<Vector3> points = new List<Vector3>();
        private static List<GameObject> obj_list;

        public static bool Test_shuffle = true;


        public static void Init(List<GameObject> _obj_list)
        {
            obj_list = _obj_list;
            foreach (var obj in obj_list)
            {
                points.Add(obj.transform.position);
            }
        }

        public static void Shuffle( Sprite sprite_ball)
        {
            InProgress = true;
            progress = shuffle_time;

            UpdateShufflePoints();
        }

        public static void UpdateShufflePoints()
        {
            foreach (var obj in obj_list)
            {
                var r = UnityEngine.Random.Range(0, obj_list.Count - 1);
                var t_pos = points[r];
                if (shuffle_point.ContainsKey(obj))
                    shuffle_point[obj] = t_pos;
                else
                    shuffle_point.Add(obj, t_pos);
            }
        }

        public static void ReturnToStartPoints()
        {
            var m = new int[5] { 2, 1, 3, 0, 4 };
            float addLeft = 5 - Roll.items_count;
            for (var i = 0; i < obj_list.Count; i++)
            {
                var obj = obj_list[i];
                var p = points[m[i]];
                if (Roll.items_count == 4)
                    p = new Vector3(p.x + addLeft / 2f, p.y, p.z);
                obj.transform.position = p;
            }
        }

        public void ReturnToPoints(float step)
        {
            var m = new int[5] { 2,1,3,0,4 };
            float addLeft = 5 - Roll.items_count;
            for (var i = 0; i < obj_list.Count; i++)
            {
                var obj = obj_list[i];
                var p = points[m[i]];
                if(Roll.items_count==4)
                    p = new Vector3(p.x+addLeft/2f,p.y,p.z);
                if (shuffle_point.ContainsKey(obj))
                    shuffle_point[obj] = p;
                else
                    shuffle_point.Add(obj, p);
            }
        }

        private float t = 0;
        void Update()
        {
            if (!Test_shuffle && !InProgress) return;
            
            progress -= Time.deltaTime;
            
            float step = shuffle_speed * Time.deltaTime;
            if(!Test_shuffle)
                if (progress <= 0)
                {
                    InProgress = false;
                
                    ImageClickScript.IsGameEnded = false;
                    return;
                }else if (progress>0.7f && progress < 1f)
                {
                    ReturnToPoints(step);
                }

            if(shuffle_point.Count == 0)
            {
                UpdateShufflePoints();
            }
            if (progress>=1f)
            {
                t += Time.deltaTime;
                if (t >= 1f / shuffle_speed)
                {
                    UpdateShufflePoints();
                    t = 0;
                }
            }

            foreach (var obj in obj_list)
            {
                var point = shuffle_point[obj];
                obj.transform.position = Vector3.MoveTowards(obj.transform.position, point, step);
            }
        }
    }
}
