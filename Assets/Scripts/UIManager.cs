using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] List<UIObject> objects;

    TextAnimationController txtAnimCont;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        txtAnimCont = FindObjectOfType<TextAnimationController>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        foreach (UIObject obj in objects)
        {
            // Coroutine return
            if (obj.returnType == DropdownMenus.ReturnTypes.WaitForDelay)
            {
                obj.coroutineReturn = new WaitForSeconds(obj.delay);
            }
            else if (obj.returnType == DropdownMenus.ReturnTypes.WaitForEndOfAction)
            {
                if (obj.coroutineAction == DropdownMenus.Actions.BlinkText)
                {
                    obj.coroutineReturn = StartCoroutine(txtAnimCont
                        .BlinkText(obj.gameObject.GetComponent<TextMeshProUGUI>(),
                        obj.blinkInterval, obj.blinkAmount));
                }
                else if (obj.coroutineAction == DropdownMenus.Actions.BlinkTextEndlessly)
                {
                    obj.coroutineReturn = StartCoroutine(txtAnimCont
                        .BlinkText(obj.gameObject.GetComponent<TextMeshProUGUI>(),
                        obj.blinkInterval));
                }
                else if (obj.coroutineAction == DropdownMenus.Actions.BlinkNewHighScore)
                {
                    obj.coroutineReturn = StartCoroutine(BlinkNewHighScore(obj.gameObject, obj.blinkInterval));
                }
                else if (obj.coroutineAction == DropdownMenus.Actions.CountUpText)
                {
                    obj.coroutineReturn = StartCoroutine(txtAnimCont
                        .CountUpEffectCoroutine(obj.gameObject.GetComponent<TextMeshProUGUI>(),
                        scoreKeeper.GetScore()));
                }
                else
                {
                    obj.coroutineReturn = null;
                }
            }
            else
            {
                obj.coroutineReturn = null;
            }

            // Action
            if (obj.actions != null && obj.actions.Count > 0)
            {
                foreach (DropdownMenus.Actions act in obj.actions)
                {
                    if (act == DropdownMenus.Actions.BlinkText)
                    {    
                        obj.actionsToExecute.Add(() => StartCoroutine(
                            txtAnimCont.BlinkText(obj.gameObject.GetComponent<TextMeshProUGUI>(),
                            obj.blinkInterval, obj.blinkAmount)));                     
                    }
                    else if (act == DropdownMenus.Actions.BlinkTextEndlessly)
                    {
                        obj.actionsToExecute.Add(() => StartCoroutine(
                            txtAnimCont.BlinkText(obj.gameObject.GetComponent<TextMeshProUGUI>(),
                            obj.blinkInterval)));
                    }
                    else if (act == DropdownMenus.Actions.BlinkNewHighScore)
                    {
                        obj.actionsToExecute.Add(() => StartCoroutine(BlinkNewHighScore(
                            obj.gameObject, obj.blinkInterval)));
                    }
                    else if (act == DropdownMenus.Actions.CountUpText)
                    {
                        obj.actionsToExecute.Add(() => StartCoroutine(txtAnimCont
                            .CountUpEffectCoroutine(obj.gameObject.GetComponent<TextMeshProUGUI>(),
                            scoreKeeper.GetScore())));
                    }
                    else if (act == DropdownMenus.Actions.SetObjectActive)
                    {
                        obj.actionsToExecute.Add(() => obj.gameObject.SetActive(true));
                    }
                }
            }
        }

        StartCoroutine(LoadScreenGradually());
    }

    IEnumerator BlinkNewHighScore(GameObject text, float interval)
    {
        if (scoreKeeper.GetHighScore() == scoreKeeper.GetScore()
            && scoreKeeper.GetHighScore() != 0)
        {
            yield return StartCoroutine(txtAnimCont.BlinkText(text.GetComponent<TextMeshProUGUI>(), interval, 2));
        }
    }

    public IEnumerator LoadScreenGradually()
    {
        foreach (UIObject obj in objects)
        {
            yield return obj.coroutineReturn;

            foreach (Action act in obj.actionsToExecute)
            {
                act();
            }
        }
    } 
}
