using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3 (h, 0, v);
        transform.position += dir * speed * Time.deltaTime;

        if(h == 0 && v == 0) return;
        Quaternion newRotation = Quaternion.LookRotation(dir * speed * Time.deltaTime);
        rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, speed * Time.deltaTime);
    }
}
