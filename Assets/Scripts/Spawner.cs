using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] List<GameObject> spawners;
    [SerializeField] GameObject projectile;

    [Header("Spawn time")]
    [SerializeField] float baseSpawnDelay = 1;
    [SerializeField] float acceleration = 1;
    [SerializeField] float accelerationIncrement = 0.05f;
    [SerializeField] float accelerationInterval = 1;

    float spawnDelayTimer;
    float accelerationTimer;

    void Update()
    {
        ProcedurallySpawn();
        IncrementAcceleration();
    }

    void Spawn(int pos)
    {
        Instantiate(projectile, spawners[pos].transform.position, Quaternion.identity);
    }

    int GetRandomSpawner()
    {
        return UnityEngine.Random.Range(0, 4);
    }

    void ProcedurallySpawn()
    {
        spawnDelayTimer += Time.deltaTime;

        if (spawnDelayTimer > Math.Round(baseSpawnDelay / acceleration, 2))
        {
            Spawn(GetRandomSpawner());
            spawnDelayTimer = 0;
        }
    }

    void IncrementAcceleration()
    {
        accelerationTimer += Time.deltaTime;

        if (accelerationTimer > accelerationInterval)
        {
            acceleration = (float)Math.Round(acceleration + accelerationIncrement, 2);
            accelerationTimer = 0;
        }
    }
}
