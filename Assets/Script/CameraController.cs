using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    private float _scrollFrom;
    [SerializeField] 
    private float _scrollTo;
    [SerializeField]
    private float _dumping = 1.5f;
    [SerializeField]
    private Vector2 _offset = new Vector2(2f, 1f);

    private Camera _camera;
    private Transform _playerRef;
    private bool isLeft;
    private int lastX;
    private void Start()
    {
        _camera = GetComponent<Camera>();
        _offset = new Vector2(Mathf.Abs(_offset.x), _offset.y);
        FindPlayer(isLeft);
    }
    void Update()
    {
       if(Input.GetAxis("Mouse ScrollWheel") > 0 && _camera.fieldOfView > _scrollFrom)
            _camera.fieldOfView--;
       else if(Input.GetAxis("Mouse ScrollWheel") < 0 && _camera.fieldOfView < _scrollTo)
            _camera.fieldOfView++;

        if (_playerRef)
        {
            int currentX = Mathf.RoundToInt(_playerRef.position.x);
            if (currentX > lastX)           
                isLeft = false;           
            else if (currentX < lastX)           
                isLeft = true;        
            lastX = Mathf.RoundToInt(_playerRef.position.x);
            Vector3 target;
            if (isLeft)
                target = new Vector3(_playerRef.position.x - _offset.x, _playerRef.position.y - _offset.y, transform.position.z);           
            else          
                target = new Vector3(_playerRef.position.x + _offset.x, _playerRef.position.y + _offset.y, transform.position.z);          
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, _dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }

    private void FindPlayer(bool playerIsLeft)
    {
        _playerRef = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(_playerRef.position.x);
        if (playerIsLeft)      
            transform.position = new Vector3(_playerRef.position.x - _offset.x, _playerRef.position.y - _offset.y, transform.position.z);
        
        else     
            transform.position = new Vector3(_playerRef.position.x + _offset.x, _playerRef.position.y + _offset.y, transform.position.z);
    }
}
