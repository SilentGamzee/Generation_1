using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main
{
    class LineGenerator:MonoBehaviour
    {
        public GameObject lineHolder;

        private static GameObject _lineHolder;
        private static List<GameObject> lines = new List<GameObject>();
        void Start()
        {
            _lineHolder = lineHolder;
        }

        public static GameObject GenerateLine(Vector3 start, Vector3 end)
        {
            GameObject newLineGen = Instantiate(_lineHolder);
            LineRenderer lRend = newLineGen.GetComponent<LineRenderer>();
            lRend.positionCount = 2;
            lRend.SetPosition(0, start-new Vector3(0,0, 0.3f));
            lRend.SetPosition(1, end - new Vector3(0, 0, 0.3f));
            lines.Add(newLineGen);
            return newLineGen;
        }


        public static void ClearLines()
        {
            foreach (var line in lines)
                Destroy(line);

            lines.Clear();
        }
    }
}
