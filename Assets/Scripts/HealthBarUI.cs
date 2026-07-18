using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class HealthBarUI : MonoBehaviour
{
    public float Health = 20;
    public float MaxHealth = 100;
    public float Width = 1350;
    public float Height = 50;

    [SerializeField]
    private RectTransform healthBar;

    public void SetMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        Health = health;
        float newWidth = (Health / MaxHealth) * Width;

        healthBar.sizeDelta = new Vector2(newWidth, Height);
    }
}
