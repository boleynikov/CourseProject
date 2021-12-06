using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Enemy : MonoBehaviour
{
    public float Health { get; private set; } = 0.5f;

    private Rigidbody2D rb;
    //private Vector2 movement;
    private float speed = 2f;
    private float minimumDistance = 6f;
    private float shootingDistance = 9f;
    //private PhotonView view;
    private Transform target;
    bool faceWithObstacle = false;

    public bool shootAbility { get; private set; } = true;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _shootPoint;
    private Animator _animator;
    [SerializeField]
    float startTimeBtwShots;
    float timeBeetweenShots = 0;
    void Start()
    {
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(target == null)                                                  // TODO:    
            target = GameObject.FindGameObjectWithTag("Player").transform;  //  Finding player position by enemy spawner
        RotateToTarget(); 
        
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (Vector3.Distance(transform.position, target.position) <= minimumDistance)
            return;
        else if (Vector3.Distance(transform.position, target.position) < shootingDistance)
            Shoot();
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        if(!faceWithObstacle)
            rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
    private void RotateToTarget()
    {
        float angle, offset = 90f;
        float x = target.position.x - transform.position.x;
        float y = target.position.y - transform.position.y;
        angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - offset);
    }
    public void TakeDamage(float _damage)
    {
        if (Health <= 0)
            PhotonNetwork.Destroy(gameObject);
        Health -= _damage;
        Debug.Log($"Enemy {Health} HP left");
    }
    private void Shoot()    // TODO:    
    {                       //  enemy shooting
        if (timeBeetweenShots <= 0)
        {
            shootAbility = true;
                _animator.SetBool("IsShooting", true);
                timeBeetweenShots = startTimeBtwShots;
                shootAbility = false;
                PhotonNetwork.Instantiate(_bullet.name, _shootPoint.position, transform.rotation);            
        }
        else
        {          
            _animator.SetBool("IsShooting", false);
            timeBeetweenShots -= Time.deltaTime;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        faceWithObstacle = true;
        Vector2 direction = new Vector2(collision.GetContact(0).point.x <= transform.position.x ? 1 : -1,
                                        collision.GetContact(0).point.y <= transform.position.y ? 1 : -1);      
        rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
        Debug.Log($" Contact point {collision.GetContact(0).point} Enemy {transform.position}");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        faceWithObstacle = false;
    }
}
