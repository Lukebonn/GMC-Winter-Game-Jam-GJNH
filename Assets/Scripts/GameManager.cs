using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool spawning = false;
    [SerializeField] private TextMeshProUGUI numEnemyHits;
    [SerializeField] private GameObject LevelUpUI;
    private float currNum = 0f;

    void Start()
    {
        spawning = true;
        numEnemyHits.SetText(((int)currNum).ToString());
        LevelUpUI.SetActive(false);
    }
    private void OnEnable()
    {
        enemyPrefab.OnEnemyHit += PetHit;
        Pet.OnEvolve += LevelUpIndicator;
    }
    private void OnDisable()
    {
        enemyPrefab.OnEnemyHit -= PetHit;
        Pet.OnEvolve -= LevelUpIndicator;
    }
    private void OnDestroy()
    {
        enemyPrefab.OnEnemyHit -= PetHit;
        Pet.OnEvolve -= LevelUpIndicator;
    }
    private void PetHit()
    {
        //Debug.Log($"PetHit at {Time.time}");
        currNum++;
        numEnemyHits.SetText(((int)currNum).ToString());
    }
    private void LevelUpIndicator(int level)
    {
        int newLevel = level;
        StartCoroutine(showLevelUpUI());
    }

    private IEnumerator showLevelUpUI()
    {
        LevelUpUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        LevelUpUI.SetActive(false);
    }
}
