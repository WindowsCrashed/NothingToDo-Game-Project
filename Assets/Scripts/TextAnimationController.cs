using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class TextAnimationController : MonoBehaviour
{
    [Header("Bounce Effect")]
    [SerializeField] float moveDistance = 5f;
    [SerializeField] float moveSpeed = 0.1f;

    [Header("Count Effect")]
    [SerializeField] int incrementValue = 5;

    [Header("Blink Effect")]
    [SerializeField] float blinkInterval = 0.5f;

    public Coroutine isSomethingThere; 

    bool wasSkipped; // Flag for coroutines


    void Start()
    {

    }

    void Update()
    {

    }

    void OnTouchInput(InputValue value)
    {
        SkipAnimationCoroutines();
    }

    void SkipAnimationCoroutines()
    {
        wasSkipped = true;
    }

    public void BounceTextAnimation(GameObject text)
    {
        LeanTween.moveY(text, text.transform.position.y + moveDistance, moveSpeed)
            .setEaseInExpo().setOnComplete(
            () => LeanTween.moveY(text, text.transform.position.y - moveDistance, moveSpeed)
            .setEaseInExpo()).setIgnoreTimeScale(true);
    }

    public IEnumerator CountUpEffectCoroutine(TextMeshProUGUI text, int value)
    {
        int count = 0;

        while (count <= value)
        {
            if (wasSkipped)
            {
                text.text = value.ToString();
                break;
            }

            text.text = count.ToString();
            count += incrementValue;
            Mathf.Clamp(count, 0, value);

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator BlinkTextNoInterval(TextMeshProUGUI text)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(blinkInterval);
            text.alpha = Mathf.Abs(text.alpha - 1);
        }
    }

    public IEnumerator BlinkTextNoInterval(TextMeshProUGUI text, int repeat)
    {
        repeat *= 2;

        for (int i = 0; i < repeat; i++)
        {
            yield return new WaitForSecondsRealtime(blinkInterval);
            text.alpha = Mathf.Abs(text.alpha - 1);
        }
    }

    public IEnumerator BlinkText(TextMeshProUGUI text, float interval)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(interval);
            text.alpha = Mathf.Abs(text.alpha - 1);
        }
    }

    public IEnumerator BlinkText(TextMeshProUGUI text, float interval, int repeat)
    {
        repeat *= 2;

        for (int i = 0; i < repeat; i++)
        {
            yield return new WaitForSecondsRealtime(interval);
            text.alpha = Mathf.Abs(text.alpha - 1);
        }
    }
}
