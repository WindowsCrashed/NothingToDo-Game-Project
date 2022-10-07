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

    int score = 0;
    string status;

    void Awake()
    {
        canvasControl = FindObjectOfType<CanvasController>();
    }

    void Start()
    {
        //status = "Nice";
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

    public void CalculateScore(float distance)
    {
        int points = 0;

        if (distance >= missMark)
        {
            status = "Miss";
            points = missPoints;
        }
        else if (distance >= badMark)
        {
            status = "Bad";
            points = badPoints;
        }
        else if (distance >= goodMark)
        {
            status = "Good";
            points = goodPoints;
        }
        else if (distance >= perfectMark)
        {
            status = "Perfect";
            points = perfectPoints;
        } else
        {
            status = "???";
        }

        UpdateScore(points);
        canvasControl.ThrowStatusMessage();
        //Debug.Log(status);
        //Debug.Log(distance);
    }
}
