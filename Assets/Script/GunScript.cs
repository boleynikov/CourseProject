using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _shootPoint;

    [SerializeField] float startTimeBtwShots;
    float timeBtwShots = 0;
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(_bullet, _shootPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
