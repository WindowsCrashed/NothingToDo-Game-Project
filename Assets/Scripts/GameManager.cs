using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] float globalAcceleration = 0.01f;
    [SerializeField] float accelerationIncrement = 0.01f;
    [SerializeField] float accelerationInterval = 1;

    float timer;

    void Start()
    {
        
    }

    void Update()
    {
        CheckPlayerHp();
        IncrementAcceleration();
    }

    void IncrementAcceleration()
    {
        timer += Time.deltaTime;

        if (timer > accelerationInterval)
        {
            globalAcceleration = (float)Math.Round(globalAcceleration + accelerationIncrement, 2);
            timer = 0;
        }
    }

    void CheckPlayerHp()
    {
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(0);
    }

    public void TakeLife()
    {
        hp--;
    }

    public float GetGlobalAcceleration()
    {
        return globalAcceleration;
    }
}
