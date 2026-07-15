using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);

        transform.position += direction * speed * Time.deltaTime;
    }
}
