using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image helthbar;
    public float helthCO;
    float maxHelth = 100f;
    Player  Player;

    private void Start()
    {
        helthbar = GetComponent<Image>();
        Player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        helthCO = Player.health;
        helthbar.fillAmount = helthCO / maxHelth;
    }
}
