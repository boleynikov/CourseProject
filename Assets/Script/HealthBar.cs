using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image _bar;
    [SerializeField]
    private float fill = 0;
    void Update()
    {
        _bar.fillAmount = fill;
    }
    public void BindBarToPlayer(GameObject player)
    {
        fill = player.GetComponent<Player>().Health;
        _bar.fillAmount = fill;
    }
}
