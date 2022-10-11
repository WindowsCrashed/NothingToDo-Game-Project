using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TextMeshProUGUI statusText;
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("Tap area")]
    [SerializeField] List<GameObject> tapAreaButtonGroups;

    TextAnimationController txtAnimCont;
    ScoreKeeper scoreKeeper;
    GameManager gameManager;

    void Awake()
    {
        txtAnimCont = FindObjectOfType<TextAnimationController>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        gameManager = FindObjectOfType<GameManager>();

        statusText.text = string.Empty;
    }

    void Update()
    {
        UpdateScoreText(scoreKeeper.GetScore());
    }

    void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ThrowStatusMessage()
    {
        statusText.text = scoreKeeper.GetStatus();
        txtAnimCont.BounceTextAnimation(statusText.gameObject);
    }

    public void ThrowStatusMessage(string message)
    {
        statusText.text = message;
        txtAnimCont.BounceTextAnimation(statusText.gameObject);
    }

    public void BlinkStatusMessage()
    {
        StartCoroutine(txtAnimCont.BlinkTextNoInterval(statusText));
    }

    public void DisableTapInteraction()
    {
        foreach (GameObject btnGroup in tapAreaButtonGroups)
        {
            btnGroup.SetActive(false);
        }
    }

    public void ProcessPlayerDeath()
    {
        DisableTapInteraction();
        BlinkStatusMessage();
    }
}
