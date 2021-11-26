using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
   
    public Canvas _healthCanvas;
    [SerializeField]
    private Image _bar;
    [SerializeField]
    private float fill = 0;

    void Awake()
    {
        _bar = gameObject.GetComponent<Image>();
    }

    public void BindBarToPlayer(GameObject player)
    {
        fill = player.GetComponent<Player>().Health;
        _bar.fillAmount = fill;
    }
    void Update()
    {
        _bar.fillAmount = fill;
    }
}
