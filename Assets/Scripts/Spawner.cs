using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1f;
    public float spawnRateCollectable = 1f;

    public GameObject collectablePrefab;
    public GameObject[] shapesPrefabs;
    public int nextSpawnedShapeNumber;

    private float nextTimeToSpawn = 0f;
    private float nextTimeToSpawnCollectable = 0f;

    private void Update()
    {
        nextSpawnedShapeNumber = Random.Range(0, shapesPrefabs.Length);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-2, 2), Random.Range(-4, 4), 0);

        if (Time.time >= nextTimeToSpawn)
        {
            Instantiate(shapesPrefabs[nextSpawnedShapeNumber], Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + 1f / spawnRate;
        }

        if(Time.time >= nextTimeToSpawnCollectable)
        { 
            Instantiate(collectablePrefab, randomSpawnPosition, Quaternion.identity);
            nextTimeToSpawnCollectable = Time.time + 1f / spawnRateCollectable;
        }
    }
}
