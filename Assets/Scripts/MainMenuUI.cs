using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TextMeshProUGUI superTitleText;
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI highScoreTitleText;
    [SerializeField] TextMeshProUGUI highScoreText;

    [Header("Buttons")]
    [SerializeField] GameObject buttonGroup;

    [Header("Delay")]
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

        StartCoroutine(LoadScreenGradually());
    }

    IEnumerator LoadScreenGradually()
    {
        yield return new WaitForSeconds(baseDelay);

        superTitleText.gameObject.SetActive(true);

        yield return new WaitForSeconds(baseDelay + 1);

        titleText.gameObject.SetActive(true);

        yield return new WaitForSeconds(baseDelay + 0.5f);

        buttonGroup.SetActive(true);
        StartCoroutine(txtAnimCont.BlinkText(buttonGroup.GetComponentInChildren<TextMeshProUGUI>()));
        highScoreTitleText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
    }
}
