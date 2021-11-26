using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private HealthBar healthBar;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        var _player = PhotonNetwork.Instantiate(_playerPrefab.name, randomPosition, Quaternion.identity);
        healthBar.BindBarToPlayer(_player);
    }
}
