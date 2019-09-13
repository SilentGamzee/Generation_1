using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public ObjectSpawner[] objectSpawners;

  /*  private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        yield return new WaitForSecondsRealtime(2f);
      
        StartCoroutine(Spawner());
        yield return null;
    }*/
    public void Spawn()
    {
        int rand = Random.Range(0, objectSpawners.Length - 1);
        objectSpawners[rand].Spawn();
    }
}
