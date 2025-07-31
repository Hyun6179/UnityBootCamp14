using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Play : MonoBehaviour
{
    private Vector2 moveInputValue;
    private float speed = 1.0f;

    void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
    }
    void Update()
    {
        Vector3 move = new Vector3(moveInputValue.x, 0, moveInputValue.y);
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}
