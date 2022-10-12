using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TextMeshProUGUI superTitleText;
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI highScoreTitleText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI playButtonText;

    [Header("Delay")]
    [SerializeField] float baseDelay;

    [Header("Button")]
    [SerializeField] Button playButton;

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
        StartCoroutine(LoadScreenGradually());
    }

    IEnumerator LoadScreenGradually()
    {
        yield return new WaitForSeconds(baseDelay + 0.72f);

        superTitleText.alpha = 1;

        yield return new WaitForSeconds(baseDelay + 1.1f);

        titleText.alpha = 1;

        yield return new WaitForSeconds(baseDelay + 0.6f);

        playButtonText.alpha = 1;
        playButton.interactable = true;
        StartCoroutine(txtAnimCont.BlinkText(playButtonText));
        highScoreTitleText.alpha = 1;
        highScoreText.alpha = 1;
    }
}
