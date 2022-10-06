using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    BoxCollider2D col2d;
    Transform mark;
    GameObject projectile;
    ScoreKeeper scoreKeeper;

    bool isPressedOnTime;

    void Awake()
    {
        col2d = GetComponent<BoxCollider2D>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        mark = transform.Find("Mark").transform;
    }

    void Start()
    {
        
    }

    void Update()
    {
        ActivateTarget();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        projectile = collision.gameObject;
    }

    void ActivateTarget()
    {
        if (isPressedOnTime)
        {
            scoreKeeper.CalculateScore(GetMarkDistance());

            Destroy(projectile);
            isPressedOnTime = false;
        }
    }

    bool CheckForTarget()
    {
        return col2d.IsTouchingLayers(LayerMask.GetMask("Projectile"));
    }

    float GetMarkDistance()
    {
        return Vector2.Distance(mark.position, projectile.transform.Find("Mark").transform.position);
    }

    public void OnTapTarget()
    {
        if (CheckForTarget())
        {
            isPressedOnTime = true;
        } else
        {
            isPressedOnTime = false;
        }
    }
}
