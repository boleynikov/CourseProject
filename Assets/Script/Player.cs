using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Health { get; private set; } = 1f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float speed = 3f;

    private PhotonView view;

    void Start()
    {   
        rb = gameObject.GetComponent<Rigidbody2D>();
        view = gameObject.GetComponent<PhotonView>();
    }
    void Update()
    {
        if (!view.IsMine)
            return;
        RotateToCursor();
        MovePlayer();
    }
    public void TakeDamage(float _damage)
    {
        if (!view.IsMine)
            return;
        Health -= _damage;
        if (Health <= 0)
        {
            PhotonNetwork.Destroy(gameObject);
            Debug.Log($"Player {view.ViewID} died");
        }
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
