using UnityEngine;
using System.Collections;

public class PetManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyDropzoneObject;
    [SerializeField] int pointsPerEnemy = 40;
    [SerializeField] private Pet pet;

    private BoxCollider2D enemyDropZone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyDropZone = enemyDropzoneObject.GetComponent<BoxCollider2D>();
    }
    private void OnEnable()
    {
        DragAll.OnEnemyDropped += HandleRelease;
    }

    private void OnDisable()
    {
        DragAll.OnEnemyDropped -= HandleRelease;
    }

    private void HandleRelease(Vector2 position, enemyPrefab EnemyPrefab)
    {
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        if (enemyDropZone.OverlapPoint(position))
        {
            pet.SetHealth(pointsPerEnemy);
            StartCoroutine(DestroyEnemyAfterDelay(EnemyPrefab));
        }
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    private IEnumerator DestroyEnemyAfterDelay(enemyPrefab enemy)
    {
        yield return new WaitForSeconds(1f);

        if (enemy != null)
        {
            enemy.destroyEnemy();
        }
    }
}
