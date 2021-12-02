using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCursorRotation : MonoBehaviour
{
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle, offset = 90f;
    void Update()
    {
        mouse_pos = Input.mousePosition;
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - offset);
    }
}
