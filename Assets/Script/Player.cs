using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private float speed = 3f;
    public float Health { get; private set; } = 0.2f;

    private PhotonView view;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        view = gameObject.GetComponent<PhotonView>();  
    }

   
    void Update()
    {
        if (view.IsMine)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
        }
    }
    public void TakeDamage(float _damage)
    {
        Health -= _damage;
    }
}
