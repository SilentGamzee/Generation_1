using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] prefab;

    public void Spawn()
    {
        int rand = Random.Range(0, prefab.Length - 1);
        GameObject obj = Instantiate(prefab[rand], transform);
        obj.transform.localPosition = Vector3.zero;
    }
}