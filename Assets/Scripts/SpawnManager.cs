using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject spaceship;
    public GameObject powerUp;
    public GameUI gameUI;

    private float ySpawnPos = 4;
    private float zSpawnPos = 21;
    private float xSpawnRange = 13;

    void Start()
    {
        StartCoroutine(spawnObjects());
        StartCoroutine(spawnSpaceship());
        StartCoroutine(spawnPowerUp());
    }

    IEnumerator spawnObjects()
    {
        yield return new WaitForSeconds(1);
        while (gameUI.isLife)
        {
            yield return new WaitForSeconds(Random.Range(0.6f, 1.5f));
            Instantiate(obstacle, SpawnPos(), obstacle.transform.rotation);
        }
    }

    IEnumerator spawnSpaceship()
    {
        yield return new WaitForSeconds(1);
        while (gameUI.isLife)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2.2f));
            Instantiate(spaceship, SpawnPos(), spaceship.transform.rotation);
        }
    }

    IEnumerator spawnPowerUp()
    {
        yield return new WaitForSeconds(1);
        while (gameUI.isLife)
        {
            yield return new WaitForSeconds(Random.Range(7f, 9f));
            Instantiate(powerUp, SpawnPos(), powerUp.transform.rotation);
        }
    }

    Vector3 SpawnPos()
    {
        float xSpawnPos = Random.Range(-xSpawnRange, xSpawnRange);
        return new Vector3(xSpawnPos, ySpawnPos, zSpawnPos);
    }

}
