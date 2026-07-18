using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = 10f; // Distance from the camera in units
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = worldPos;
    }
}