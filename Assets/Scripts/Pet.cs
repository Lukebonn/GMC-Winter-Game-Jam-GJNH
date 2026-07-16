using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Pet : MonoBehaviour
{
    public float Health = 80;
    public float MaxHealth = 100;

    [SerializeField]
    private HealthBarUI healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
    }

    void Update()
    {
        if(Input.GetKeyDown("k"))
        {
            SetHealth(-20f);
        }
        if (Input.GetKeyDown("l"))
        {
            SetHealth(20f);
        }
    }

    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        healthBar.SetHealth(Health);
    }
}
