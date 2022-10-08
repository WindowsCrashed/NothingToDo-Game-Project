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
            count += 5;
            Mathf.Clamp(count, 0, value);

            yield return new WaitForEndOfFrame();
        }
    }

    public void BounceTextAnimation(GameObject text)
    {
        LeanTween.moveY(text, text.transform.position.y + moveDistance, moveSpeed)
            .setEaseInExpo().setOnComplete(
            () => LeanTween.moveY(text, text.transform.position.y - moveDistance, moveSpeed)
            .setEaseInExpo()).setIgnoreTimeScale(true);
    }

    public void CountUpTextEffect(TextMeshProUGUI text, int value)
    {
        StartCoroutine(CountUpEffectCoroutine(text, value));
    }
}
