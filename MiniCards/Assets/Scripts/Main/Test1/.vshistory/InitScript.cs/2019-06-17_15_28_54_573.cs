using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Test1
{
    public class InitScript : MonoBehaviour
    {
        //PUBLIC EDITOR
        public Sprite hideSprite;
        public GameObject randomCol;

        public List<Sprite> spriteList;

        //PUBLIC STATIC
        public static InitScript _instance;

        void Awake()
        {

            _instance = this;
            UpdateImages();
            HideImages();

            randomCol.transform.GetChild(0).gameObject.SetActive(false);

            for (var i=0;i<spriteList.Count;i++)
                c_s.Add(i, 0);
            

            MoveCoordinator.Init();
        }


        private static void UpdateImages(Transform trans)
        {
            var spriteList = _instance.spriteList;
            for (var i = 0; i < trans.childCount; i++)
            {
                var r = Random.Range(0, spriteList.Count);
                var item = trans.GetChild(i);
                item.GetComponent<Image>().sprite = spriteList[r];
                item.gameObject.AddComponent<ItemInfo>().num = r;
                item.gameObject.SetActive(true);
            }
        }

        public static void UpdateImages()
        {
            for (var i = 0; i < _instance.spriteList.Count; i++)
                c_s[i] = 0;
            var r_col = _instance.randomCol.transform;
            var trans = r_col.GetChild(0);
            for (var i = 0; i < trans.childCount; i++)
                UpdateImage(trans.GetChild(i).gameObject);
        }

        private static Dictionary<int, int> c_s = new Dictionary<int, int>();
       
        public static void UpdateImage(GameObject item)
        {
            var spriteList = _instance.spriteList;

            var list = new List<int>();
            foreach(var kv in c_s)
                if (kv.Value < 2)
                    list.Add(kv.Key);

            var n = list[Random.Range(0, list.Count)];
            var r = spriteList[n];

            item.GetComponent<ItemInfo>().num = r;
            item.gameObject.SetActive(true);
        }

        public static void ShowImage(GameObject item)
        {
            var spriteList = _instance.spriteList;
            var r = item.GetComponent<ItemInfo>().num;
            item.GetComponent<Image>().sprite = spriteList[r];
        }

        public static void HideImages()
        {
            var r_col = _instance.randomCol.transform;
            var trans = r_col.GetChild(0);
            for (var i = 0; i < trans.childCount; i++)
                HideImage(trans.GetChild(i).gameObject);
        }

        private static void HideImage(GameObject item)
        {
            item.GetComponent<Image>().sprite = _instance.hideSprite;
        }
    }
}
