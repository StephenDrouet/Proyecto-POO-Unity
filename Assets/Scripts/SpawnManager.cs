using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject spaceship;

    private float ySpawnPos = 4;
    private float zSpawnPos = 21;
    private float xSpawnRange = 13;

    void Start()
    {
        StartCoroutine(spawnObjects());
        StartCoroutine(spawnSpaceship());
    }

    IEnumerator spawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            float xSpawnPos = Random.Range(-xSpawnRange, xSpawnRange);
            Vector3 spawnPos = new Vector3(xSpawnPos, ySpawnPos, zSpawnPos);
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
    }

    IEnumerator spawnSpaceship()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f, 4f));
            float xSpawnPos = Random.Range(-xSpawnRange, xSpawnRange);
            Vector3 spawnPos = new Vector3(xSpawnPos, ySpawnPos, zSpawnPos);
            Instantiate(spaceship, spawnPos, spaceship.transform.rotation);
        }
    }

}
