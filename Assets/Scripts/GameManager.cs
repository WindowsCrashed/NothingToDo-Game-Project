using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] int hp;

    [Header("Game speed")]
    [SerializeField] float speedDecrement = 0.003f;

    [Header("Delay")]
    [SerializeField] float loadSceneDelay;

    ScoreKeeper scoreKeeper;

    bool isAlive = true;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        Time.timeScale = 1;
    }

    void Update()
    {
        if (isAlive)
        {
            CheckPlayerHp();
        } else
        {
            SlowDownTime();
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
        isAlive = false;
        DisablePlayerControls();
        StartCoroutine(LoadSceneAfterDelay(LoadGameOver));
    }

    void DisablePlayerControls()
    {
        FindObjectOfType<CanvasController>().DisableTapInteraction();
    }

    void SlowDownTime()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = Mathf.Clamp(Time.timeScale - speedDecrement, 0, float.MaxValue);
        }
    }

    IEnumerator LoadSceneAfterDelay(Action loadScene)
    {
        yield return new WaitForSecondsRealtime(loadSceneDelay);

        loadScene();
    }

    public void TakeLife()
    {
        hp--;
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

    public bool GetLifeState()
    {
        return isAlive;
    }
}
