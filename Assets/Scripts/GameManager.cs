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

    ScoreKeeper scoreKeeper;

    float timer;
    int gameState;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        gameState = SceneManager.GetActiveScene().buildIndex + 1; 
    }

    void Update()
    {
        CheckPlayerHp();
        IncrementAcceleration();
    }

    void IncrementAcceleration()
    {
        if (gameState == 1)
        {
            timer += Time.deltaTime;

            if (timer > accelerationInterval)
            {
                globalAcceleration = (float)Math.Round(globalAcceleration + accelerationIncrement, 2);
                timer = 0;
            }
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
        LoadGameOver();   
    }

    public void TakeLife()
    {
        hp--;
    }

    public float GetGlobalAcceleration()
    {
        return globalAcceleration;
    }

    public void LoadMainMenu()
    {

    }

    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver()
    {
        scoreKeeper.UpdateHighScore();
        SceneManager.LoadScene("GameOver");
    }
}
