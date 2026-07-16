using System;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class enemyPrefab : MonoBehaviour
{
    private Vector2[] path;
    private float minDelay;
    private float maxDelay;
    private float speed;

    //private bool isInitialized = false;
    private int currentWaypoint = 0;
    private float delay;

    public void Initialize(
        Vector2[] path,
        float minDelay,
        float maxDelay,
        float speed)
    {
        this.path = path;
        this.minDelay = minDelay;
        this.maxDelay = maxDelay;
        this.speed = speed;
        StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        for (int i = 0; i < path.Length; i++)
        {
            delay = Random.Range(minDelay, maxDelay);
            Vector3 nextPos = new Vector3(path[i].x, path[i].y, transform.position.z);

            while ((nextPos - transform.position).sqrMagnitude > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
                yield return null;
            }
            currentWaypoint++;
            yield return new WaitForSeconds(delay);
        }
    }
}
