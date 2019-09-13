using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKorzina : MonoBehaviour
{
    public List<GameObject> korzinaList = new List<GameObject>();

    List<GameObject> appearList = new List<GameObject>();
    float t = 0;

    void Start()
    {
        korzinaList[0].SetActive(false);
    }

    void Update()
    {
        if (t <= 0) return;

        t -= Time.deltaTime;
        if (t <= 0)
            appearList.ForEach(x => x.SetActive(true));
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "korzina") return;
        if (!appearList.Contains(col.gameObject))
            appearList.Add(col.gameObject);
        t = 1f;

        col.gameObject.SetActive(false);
        col.transform.parent.gameObject.SetActive(false;)
        MoveCoordinator.P++;
        Debug.Log("P++");
    }
}
