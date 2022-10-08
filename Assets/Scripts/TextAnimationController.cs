using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimationController : MonoBehaviour
{
    [Header("Bounce Effect")]
    [SerializeField] float moveDistance = 5f;
    [SerializeField] float moveSpeed = 0.1f;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void BounceTextAnimation(GameObject text)
    {
        LeanTween.moveY(text, text.transform.position.y + moveDistance, moveSpeed)
            .setEaseInExpo().setOnComplete(
            () => LeanTween.moveY(text, text.transform.position.y - moveDistance, moveSpeed)
            .setEaseInExpo()).setIgnoreTimeScale(true);
    }
}
