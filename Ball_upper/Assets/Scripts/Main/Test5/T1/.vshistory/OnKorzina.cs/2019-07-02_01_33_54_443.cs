using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.Test5.T1
{
    public class OnKorzina:MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log(col.gameObject.name);
            if (col.gameObject.tag != "korzina") return;
            if (!appearList.Contains(col.gameObject))
                appearList.Add(col.gameObject);
            t = 1f;

            col.gameObject.SetActive(false);
            var parent = col.transform.parent.gameObject;
            EnableAnother(parent);
            IsActiveLeft = !IsActiveLeft;
            MoveCoordinator.P++;
            Debug.Log("P++");
        }
    }
}
