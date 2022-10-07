using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int hp;

    void Start()
    {
        
    }

    void Update()
    {
        CheckPlayerHp();
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
}
