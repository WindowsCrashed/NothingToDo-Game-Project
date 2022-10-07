using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnDelay;
    [SerializeField] List<GameObject> spawners;
    [SerializeField] GameObject projectile;

    GameManager gameManager;

    float timer;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        ProcedurallySpawn();
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
        timer += Time.deltaTime;

        if (timer > Math.Round(spawnDelay / gameManager.GetGlobalAcceleration(), 2))
        {
            Spawn(GetRandomSpawner());
            timer = 0;
        }
    }
}
