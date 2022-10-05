using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    BoxCollider2D col2d;
    GameObject projectile;

    bool isPressedOnTime;

    void Awake()
    {
        col2d = GetComponent<BoxCollider2D>();
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
            Destroy(projectile);
            isPressedOnTime = false;
        }
    }

    bool CheckForTarget()
    {
        return col2d.IsTouchingLayers(LayerMask.GetMask("Projectile"));
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
