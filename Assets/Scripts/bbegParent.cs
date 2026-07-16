using System;
using System.Collections;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using Random = System.Random;



public class bbegParent : MonoBehaviour
{

    [SerializeField]
    [InspectorLabel("Enemy Waypoint Count")]
    List<Transform> waypoints;
    [SerializeField]
    [InspectorLabel("Enemy Count")]
    private int enemyCount = 10;
    [SerializeField]
    [InspectorLabel("Enemy Prefab")]
    GameObject enemyPrefab;
    [SerializeField]
    [InspectorLabel("Enemy Spawn Delay")]
    float spawnDelay;
    [SerializeField]
    [InspectorLabel("Enemy Speed")]
    float speed = 10f;
    [SerializeField]
    [InspectorLabel("Minimum Enemy Delay Time At Hide Point")]
    float enemyHideDelayMin = 1f;
    [SerializeField]
    [InspectorLabel("Maximum Enemy Delay Time At Hide Point")]
    float enemyHideDelayMax = 1f;

    private GameObject enemy;
    private enemyPrefab movement;
    private Vector2[] path;
    private bool hasStartedSpawning;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initializers
        //Transform[] waypoints = GetComponentsInChildren<Transform>();
        path = new Vector2[waypoints.Count];
        for (int i = 0; i < waypoints.Count; i++)
        {
            path[i] = waypoints[i].position;
        }

        hasStartedSpawning = false;

        //Setters
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.spawning && !hasStartedSpawning)
        {
            hasStartedSpawning = true;
            StartCoroutine(BeginSpawning());
        }
    }
    private void spawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab,
            waypoints[0].position,
            Quaternion.identity);
        enemyPrefab movement = enemy.GetComponent<enemyPrefab>();

        movement.Initialize(path, enemyHideDelayMin, enemyHideDelayMax, speed);
    }

    IEnumerator BeginSpawning()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            spawnEnemy();

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
