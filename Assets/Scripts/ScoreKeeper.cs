using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [Header("Mark distance")]
    [SerializeField] float perfectMark;
    [SerializeField] float goodMark;
    [SerializeField] float badMark;
    [SerializeField] float missMark;

    [Header("Points per mark")]
    [SerializeField] int perfectPoints;
    [SerializeField] int goodPoints;
    [SerializeField] int badPoints;
    [SerializeField] int missPoints;

    [Header("Temp")]
    [SerializeField] TextMeshProUGUI scoreText;

    CanvasController canvasControl;
    GameManager gameManager;

    int score = 0;
    string status;

    void Awake()
    {
        canvasControl = FindObjectOfType<CanvasController>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        //status = "Nice";

        // For fixing stuttering (for now)
        canvasControl.ThrowStatusMessage();
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }

    void UpdateScore(int points)
    {
        score += points;
    }

    public string GetStatus()
    {
        return status;
    }

    int CalculateScore(float distance)
    {
        if (distance >= missMark)
        {
            status = "Miss";
            gameManager.TakeLife();

            return missPoints;
        }
        else if (distance >= badMark)
        {
            status = "Bad";
            return badPoints;
        }
        else if (distance >= goodMark)
        {
            status = "Good";
            return goodPoints;
        }
        else if (distance >= perfectMark)
        {
            status = "Perfect";
            return perfectPoints;
        } else
        {
            status = "???";
            return 0;
        }
        //Debug.Log(status);
        //Debug.Log(distance);
    }

    public void SetScore(float distance)
    {
        UpdateScore(CalculateScore(distance));
        canvasControl.ThrowStatusMessage();
    }
}
