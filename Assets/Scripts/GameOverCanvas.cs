using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    TextAnimationController txtAnimCont;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        txtAnimCont = FindObjectOfType<TextAnimationController>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreText.text = scoreKeeper.GetScore().ToString();
        highScoreText.text = scoreKeeper.GetHighScore().ToString();
    }
}
