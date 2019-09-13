using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKorzina : MonoBehaviour
{
    List<GameObject> appearList = new List<GameObject>();
    private float t = 0;
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "korzina") return;
        if (!appearList.ContainsKey(col.gameObject))
            appearList.Add(col.gameObject, time);
        else
            appearList[col.gameObject] = time;

        col.gameObject.SetActive(false);
        MoveCoordinator.P++;
        Debug.Log("P++");
    }
}
