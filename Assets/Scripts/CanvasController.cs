using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI statusText;

    TextAnimationController txtAnimCont;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        txtAnimCont = FindObjectOfType<TextAnimationController>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        statusText.text = string.Empty;
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
}
