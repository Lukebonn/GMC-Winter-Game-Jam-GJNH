using System;
using UnityEngine;

public class DragAll : MonoBehaviour
{
    private Transform dragging = null;
    private Vector3 offset;
    private GameObject draggingObject;
    private enemyPrefab EnemyPrefab;

    public static event Action<Vector2> OnEnemyDropped;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log(Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.PositiveInfinity, LayerMask.GetMask("Enemies"));

            if (hit)
            {
                // If we hit, record the transform of the object we hit.
                dragging = hit.transform;
                // And record the offset.
                offset = dragging.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // then we need to make sure the enemy knows it's been grabbed, so we set the gameobject to something and pull it's script to call a public function from the script
                draggingObject = hit.collider.gameObject;
                EnemyPrefab = draggingObject.GetComponent<enemyPrefab>();
                EnemyPrefab.GrabEnemy();
            }
        } else if (Input.GetMouseButtonUp(0))
        {
            // Stop dragging
            dragging = null;
            // tell the enemy it's been released
            if (EnemyPrefab)
            {
                EnemyPrefab.ReleaseGrabbedEnemy();
            }
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            OnEnemyDropped?.Invoke(mousePos);
        }

        if (dragging != null)
        {
            // Move object, takign into account original offset
            dragging.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
}
