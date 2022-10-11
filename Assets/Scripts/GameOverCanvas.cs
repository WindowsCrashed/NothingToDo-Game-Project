using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverCanvas : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TextMeshProUGUI scoreTitleText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreTitleText;
    [SerializeField] TextMeshProUGUI highScoreText;

    [Header("Buttons")]
    [SerializeField] GameObject buttonGroup;

    [Header("Delay")]
    [SerializeField] float initialDelay;
    [SerializeField] float baseDelay;

    TextAnimationController txtAnimCont;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        txtAnimCont = FindObjectOfType<TextAnimationController>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        highScoreText.text = scoreKeeper.GetHighScore().ToString();
        
        //StartCoroutine(LoadGameOverScreenGradually());
    }

    IEnumerator LoadGameOverScreenGradually()
    {
        yield return new WaitForSeconds(initialDelay);

        scoreTitleText.gameObject.SetActive(true);

        yield return new WaitForSeconds(baseDelay);

        scoreText.gameObject.SetActive(true);

        yield return StartCoroutine(txtAnimCont.CountUpEffectCoroutine(scoreText, scoreKeeper.GetScore()));
        
        yield return new WaitForSeconds(baseDelay);

        highScoreTitleText.gameObject.SetActive(true);

        yield return new WaitForSeconds(baseDelay);

        highScoreText.gameObject.SetActive(true);
        
        if (scoreKeeper.GetHighScore() == scoreKeeper.GetScore()
            && scoreKeeper.GetHighScore() != 0)
        {
            yield return StartCoroutine(txtAnimCont.BlinkTextNoInterval(highScoreText, 2));
        }

        yield return new WaitForSeconds(baseDelay);

        buttonGroup.SetActive(true);
    }
}
