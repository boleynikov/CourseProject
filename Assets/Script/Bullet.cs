using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 30;
    private float lifetime = 0.8f;
    private float distance = 0.5f;
    private float damage = 0.1f;
    [SerializeField]
    LayerMask whatIsSolid;

    RaycastHit2D hitInfo;
    void Update()
    {
        hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<Player>().TakeDamage(damage);
            }
            Destroy(gameObject);
            lifetime = 0;
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        lifetime -= Time.deltaTime;
        if (lifetime <= 0 && gameObject != null)
            Destroy(gameObject);
    }
}
