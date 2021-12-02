using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 30;
    float lifetime = 0.5f;
    float distance;
    int damage;
    LayerMask whatIsSolid;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
    }
}
