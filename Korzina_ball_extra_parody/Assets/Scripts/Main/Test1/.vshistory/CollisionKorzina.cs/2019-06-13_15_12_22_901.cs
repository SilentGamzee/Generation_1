using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKorzina : MonoBehaviour
{
    Dictionary<GameObject, float> appearList = new List<GameObject>();
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "korzina") return;

    }
}
