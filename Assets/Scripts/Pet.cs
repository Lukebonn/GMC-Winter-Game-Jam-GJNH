using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using System.Linq;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Pet : MonoBehaviour
{
    public float currHealth = 20;
    public float MaxHealth = 100;
    public float hungerDepreciationPerSecond = 1;
    [SerializeField] List<Sprite> evolutions;

    [SerializeField] private HealthBarUI healthBar;

    private int evolutionNum;
    public static event Action<int> OnEvolve;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        healthBar.SetMaxHealth(MaxHealth);
        StartCoroutine(Hunger());
        evolutionNum = 0;
        GetComponent<SpriteRenderer>().sprite = evolutions[evolutionNum];
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
        currHealth += healthChange;
        healthBar.FlashGreen(healthChange);
        if (currHealth >= 100)
        {
            Evolve();
        }
        else if (currHealth <= 0)
        {
            Devolve();
        } 
        //else
        //{
        //    currHealth += healthChange;
        //}

        healthBar.SetHealth(currHealth);
    }

    private void Evolve()
    {
        if (evolutionNum >= 4)
        {
            SceneManager.LoadScene("Win Screen");
        }
        evolutionNum++;
        OnEvolve?.Invoke(evolutionNum);
        currHealth = 20;
        GetComponent<SpriteRenderer>().sprite = evolutions[evolutionNum];
    }

    private void Devolve()
    {
        if (evolutionNum <= 0)
        {
            SceneManager.LoadScene("Lose Screen");
        }
        evolutionNum--;
        OnEvolve?.Invoke(evolutionNum);
        currHealth = 20;
        GetComponent<SpriteRenderer>().sprite = evolutions[evolutionNum];
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
