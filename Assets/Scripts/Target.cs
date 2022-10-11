using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Transform mark;
    ScoreKeeper scoreKeeper;
    CanvasController canvasControl;
    GameManager gameManager;
    Queue<GameObject> projectiles;
    AudioManager audioManager;

    bool wasDestroyed;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        canvasControl = FindObjectOfType<CanvasController>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        mark = transform.Find("Mark").transform;
        projectiles = new Queue<GameObject>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        projectiles.Enqueue(collision.gameObject);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!wasDestroyed && gameManager.GetLifeState())
        {
            projectiles.Dequeue();
            canvasControl.ThrowStatusMessage("Miss");
            gameManager.TakeLife();
            audioManager.PlayClip("Miss");
        }

        wasDestroyed = false;
    }

    float GetMarkDistance(Transform projTrans)
    {
        return Vector2.Distance(mark.position, projTrans.Find("Mark").transform.position);
    }

    [RuntimeInitializeOnLoadMethod]
    public void OnTap()
    {
        if (projectiles.Count > 0)
        {
            GameObject currentProj = projectiles.Dequeue();

            scoreKeeper.SetScore(GetMarkDistance(currentProj.transform));
            canvasControl.ThrowStatusMessage();
            
            if (scoreKeeper.GetStatus() == "Miss")
            {
                gameManager.TakeLife();
            }

            audioManager.PlayClip(scoreKeeper.GetStatus());

            wasDestroyed = true;
            Destroy(currentProj);         
        }
    }
}
