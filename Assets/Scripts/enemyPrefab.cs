using System;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;


public class enemyPrefab : MonoBehaviour
{
    private Vector2[] path;
    private float minDelay;
    private float maxDelay;
    private float speed;

    public bool running = true;
    public bool grabbed = false;
    public bool hiding = false;
    private int currentWaypoint = 0;
    private float delay;

    // Animations
    [SerializeField] private Animator _animator;

    // Dragging stuff
    //private Vector3 offset;

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

    void Update()
    {
        if (running)
        {
            _animator.SetBool("isRunning", true);
            _animator.SetBool("isGrabbed", false);
            _animator.SetBool("isHiding", false);
        }
        else if (grabbed)
        {
            //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

            _animator.SetBool("isHiding", false);
            _animator.SetBool("isRunning", false);
            _animator.SetBool("isGrabbed", true);
        }
        else if (hiding)
        {
            _animator.SetBool("isHiding", true);
            _animator.SetBool("isGrabbed", false);
            _animator.SetBool("isRunning", false);
        }
    }

    //private void OnMouseDown()
    //{
    //    offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    grabbed = true;
    //}
    //private void OnMouseUp()
    //{
    //    grabbed = false;
    //}
    public void GrabEnemy()
    {
        grabbed = true;
        Debug.Log("Enemy Grabbed");
    }
    public void ReleaseGrabbedEnemy()
    {
        grabbed = false;
        Debug.Log("Enemy released");
    }

    // Enemy standard traversal movement
    IEnumerator Run()
    {
        for (int i = 0; i < path.Length; i++)
        {
            // Setting next waypoint from the array of points
            delay = Random.Range(minDelay, maxDelay);
            Vector3 nextPos = new Vector3(path[i].x, path[i].y, transform.position.z);
            Vector3 direction = nextPos - transform.position;

            direction.z = 0;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle);

            // Keep sprite upright
            if (angle > 90 || angle < -90)
            {
                Vector3 scale = transform.localScale;
                scale.y = -Mathf.Abs(scale.y);
                transform.localScale = scale;
            }
            else
            {
                Vector3 scale = transform.localScale;
                scale.y = Mathf.Abs(scale.y);
                transform.localScale = scale;
            }

            // Traveling to the way point
            transform.right = direction;
            running = true;

            while ((nextPos - transform.position).sqrMagnitude > 0.01f)
            {
                if (grabbed)
                {
                    running = false;
                    yield break;   // Ends the coroutine completely
                }
                transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
                yield return null;
            }
            running = false;
            currentWaypoint++;
            yield return new WaitForSeconds(delay);
        }
    }
}
