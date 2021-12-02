using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float Health { get; private set; } = 0.2f;
    private float speed = 3f;

    private PhotonView view;


    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        view = gameObject.GetComponent<PhotonView>();  
    }
    void Update()
    {
        if (view.IsMine)
        {
            RotateToCursor();
            MovePlayer();
            if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
                _animator.SetBool("IsShooting", true);
            else if(Input.GetMouseButtonUp(0))
                _animator.SetBool("IsShooting", false);
        }
    }
    public void TakeDamage(float _damage)
    {
        Health -= _damage;
    }
   private void MovePlayer()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }
    private void RotateToCursor()
    {
        Vector3 mouse_pos;
        Vector3 object_pos;
        float angle, offset = 90f;
        mouse_pos = Input.mousePosition;
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - offset);
    }
}
