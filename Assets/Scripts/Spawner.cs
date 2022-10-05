using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnDelay;
    [SerializeField] List<GameObject> spawners;
    [SerializeField] GameObject projectile;

    float timer;

    void Start()
    {
        
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
        return Random.Range(0, 4);
    }

    void ProcedurallySpawn()
    {
        timer += Time.deltaTime;

        if (timer > spawnDelay)
        {
            Spawn(GetRandomSpawner());
            timer = 0;
        }
    }
}
