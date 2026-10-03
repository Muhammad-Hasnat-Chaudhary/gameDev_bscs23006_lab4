using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // WASD Movement
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(
            move.normalized * moveSpeed * Time.deltaTime
        );

        // Keep player on ground
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Jump with Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(
                jumpHeight * -2f * gravity
            );
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(
            velocity * Time.deltaTime
        );
    }
}