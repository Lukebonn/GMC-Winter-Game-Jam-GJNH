using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] private Sprite closedHand;
    [SerializeField] private Sprite openHand;

    private SpriteRenderer sr;

    void Awake()
    {
        Cursor.visible = false;
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = 10f; // Distance from the camera in units
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = worldPos;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Quit Screen");
        }
    }
    private void OnMouseDown()
    {
        sr.sprite = closedHand;
    }
    private void OnMouseUp()
    {
        sr.sprite = openHand;
    }
}