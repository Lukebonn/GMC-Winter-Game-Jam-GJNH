using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using System.Linq;
using UnityEngine.UIElements;

public class Pet : MonoBehaviour
{
    public float Health = 20;
    public float MaxHealth = 100;
    public float hungerDepreciationPerSecond = 1;

    [SerializeField]
    private HealthBarUI healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
        StartCoroutine(Hunger());
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

    IEnumerator Hunger()
    {
        while (true)
        {
            SetHealth(-1f);
            yield return new WaitForSeconds(hungerDepreciationPerSecond);
            //yield return null;
        }
    }
}
