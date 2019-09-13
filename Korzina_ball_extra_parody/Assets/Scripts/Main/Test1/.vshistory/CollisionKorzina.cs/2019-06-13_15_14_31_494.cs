using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKorzina : MonoBehaviour
{
    Dictionary<GameObject, float> appearList = new Dictionary<GameObject, float>();
    private const float time = 1f;
    void Update()
    {
        foreach(var kv in appearList)
        {
            if()
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "korzina") return;
        if (!appearList.ContainsKey(col.gameObject))
            appearList.Add(col.gameObject, time);
        else
            appearList[col.gameObject] = time;


    }
}
