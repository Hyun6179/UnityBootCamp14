using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    void Start()
    {
        speed = 3f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical).normalized;

        rb.MovePosition (rb.position + move * speed * Time.deltaTime);

        if (horizontal == 0 && vertical == 0) return;
        rb.rotation = Quaternion.LookRotation(move);
    }
}
