using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool spawning = false;
    [SerializeField] private TextMeshProUGUI numEnemyHits;
    private float currNum = 0f;
    void Start()
    {
        spawning = true;
        numEnemyHits.SetText(((int)currNum).ToString());
    }
    private void OnEnable()
    {
        enemyPrefab.OnEnemyHit += PetHit;
    }
    private void OnDisable()
    {
        enemyPrefab.OnEnemyHit -= PetHit;
    }
    private void PetHit()
    {
        //Debug.Log($"PetHit at {Time.time}");
        currNum++;
        numEnemyHits.SetText(((int)currNum).ToString());
    }

    //public UnityEvent onKeyPressed;

    //void Update()
    //{
    //    foreach (KeyCode key in triggerKeys)
    //    {
    //        if (Input.GetKeyDown(key))
    //        {
    //            onKeyPressed?.Invoke();
    //            return;
    //        }
    //    }
    //}
}
