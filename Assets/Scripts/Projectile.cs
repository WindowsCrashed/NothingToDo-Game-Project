using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = new Vector2(transform.position.x,
            transform.position.y - speed * Time.deltaTime);
    }
}
