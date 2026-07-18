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

    private Image healthBarImage;

    private void Awake()
    {
        healthBarImage = healthBar.GetComponent<Image>();
    }

    public void SetMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        Health = health;
        float newWidth = (Health / MaxHealth) * Width;

        healthBar.sizeDelta = new Vector2(newWidth, Height);

        //StartCoroutine(FlashGreen(health));
    }

    public IEnumerator FlashGreen(float health)
    {
        if (health >= 0)
        {
            healthBarImage.color = Color.green;
            yield return new WaitForSeconds(1f);
            healthBarImage.color = Color.red;
        }
        yield return null;
    }
}
 