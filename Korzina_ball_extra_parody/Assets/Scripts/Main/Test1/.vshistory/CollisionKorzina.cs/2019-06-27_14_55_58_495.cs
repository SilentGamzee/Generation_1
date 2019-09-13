using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKorzina : MonoBehaviour
{
    public List<GameObject> korzinaList = new List<GameObject>();
    public GameObject top;
    public GameObject bot;

    List<GameObject> appearList = new List<GameObject>();
    float t = 0;

    public static bool IsActiveLeft = true;

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

    void EnableAnother(GameObject parent)
    {
        parent.SetActive(false);
        foreach (var obj in korzinaList)
            if (obj != parent)
            {
                obj.SetActive(true);
                break;
            }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
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
