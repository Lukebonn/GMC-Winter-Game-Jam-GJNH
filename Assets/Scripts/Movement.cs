using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    private void Update()
    {
        Debug.Log("Update running");
        //Debug.Log($"H: {horizontal} V: {vertical}");

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);

        transform.position += direction * speed * Time.deltaTime;
    }
}
