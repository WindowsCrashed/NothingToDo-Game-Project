using System.Collections;
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

    [Header("Dependencies")]
    [SerializeField] TextAnimationController txtAnimCont;

    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        highScoreText.text = scoreKeeper.GetHighScore().ToString();
    }

    void Start()
    {   
        StartCoroutine(LoadGameOverScreenGradually());
    }

    IEnumerator LoadGameOverScreenGradually()
    {
        yield return new WaitForSeconds(initialDelay);

        scoreTitleText.alpha = 1;

        yield return new WaitForSeconds(baseDelay);

        scoreText.alpha = 1;

        yield return StartCoroutine(txtAnimCont.CountUpEffectCoroutine(scoreText, scoreKeeper.GetScore()));
        
        yield return new WaitForSeconds(baseDelay);

        highScoreTitleText.alpha = 1;

        yield return new WaitForSeconds(baseDelay);

        highScoreText.alpha = 1;

        if (scoreKeeper.GetHighScore() == scoreKeeper.GetScore()
            && scoreKeeper.GetHighScore() != 0)
        {
            yield return StartCoroutine(txtAnimCont.BlinkText(highScoreText, 2));
        }

        yield return new WaitForSeconds(baseDelay);

        buttonGroup.SetActive(true);
    }
}
