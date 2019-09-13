using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKorzina : MonoBehaviour
{
    Dictionary<GameObject, float> appearList = new Dictionary<GameObject, float>();
    private const float time = 1f;
    void Update()
    {
        var keys = appearList.Keys;
        foreach(var obj in keys)
        {
            var v = appearList[obj];
            if (v > 0)
                appearList[obj] -= Time.deltaTime;
            else
                obj.gameObject.SetActive(true);
        }
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
