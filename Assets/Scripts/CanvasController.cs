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

    [Header("Dependencies")]
    [SerializeField] TextAnimationController txtAnimCont;
    [SerializeField] GameManager gameManager;
    
    ScoreKeeper scoreKeeper;    

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

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
        StartCoroutine(txtAnimCont.BlinkText(statusText));
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
