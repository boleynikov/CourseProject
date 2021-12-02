using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Gun : MonoBehaviour
{
    public static Gun _instance;
    public bool shootAbility { get; private set; } = true;
    [SerializeField] 
    private GameObject _bullet;
    [SerializeField] 
    private Transform _shootPoint;
    private Animator _animator;
    [SerializeField] 
    float startTimeBtwShots;
    float timeBeetweenShots = 0;

    private PhotonView view;
    private void Start()
    {
        _instance = this;
        _animator = gameObject.GetComponent<Animator>();
        view = gameObject.GetComponent<PhotonView>();
    }
    void Update()
    {
        if (view.IsMine)
        {
            if (timeBeetweenShots <= 0)
            {
                shootAbility = true;
                if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
                {

                    _animator.SetBool("IsShooting", true);
                    timeBeetweenShots = startTimeBtwShots;
                    shootAbility = false;
                    PhotonNetwork.Instantiate(_bullet.name, _shootPoint.position, transform.rotation);

                }
            }
            else
            {
                if (Input.GetMouseButtonUp(0))
                    _animator.SetBool("IsShooting", false);
                timeBeetweenShots -= Time.deltaTime;
            }
        }
    }
}
