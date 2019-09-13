using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum StatusObj
    {
        GoodObject = 0,
        BadObject = 1
    };
    public StatusObj status;

    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
    }
}
