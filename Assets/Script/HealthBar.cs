using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image _bar;

    GameObject _playerRef;
    void Update()
    {
        if (_playerRef != null)
            _bar.fillAmount = _playerRef.GetComponent<Player>().Health;
        else
            _bar.fillAmount = 0;
    }
    public void BindBarToPlayer(GameObject player)
    {
        _playerRef = player;
    }
}
