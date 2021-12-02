using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    [SerializeField] float from;
    [SerializeField] float to;
    private Camera _camera;
    private void Start()
    {
        _camera = GetComponent<Camera>();
    }
    void Update()
    {
       if(Input.GetAxis("Mouse ScrollWheel") > 0 && _camera.fieldOfView > from)
            _camera.fieldOfView--;
       else if(Input.GetAxis("Mouse ScrollWheel") < 0 && _camera.fieldOfView < to)
            _camera.fieldOfView++;
    }
}
