using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiepeSpawner : MonoBehaviour
{
    public Pipe pipe;
    public float spawnDistance = 5;
    public float spawnDelay = 2 ;
    public float randomRange = 3;
    float random;
    private void OnEnable()
    {
        Invoke("SpawnPipe", spawnDelay);
    }

    private void OnDisable()
    {
        CancelInvoke("SpawnPipe");
    }

    void SpawnPipe()
    {
        random = Random.Range(-randomRange, randomRange);
        Instantiate(pipe, new Vector3(spawnDistance, random), Quaternion.identity);
        Invoke("SpawnPipe", spawnDelay);
    }
}
