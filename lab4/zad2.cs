using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float speed = 10.0f;
    private float jumpForce = 1.0f;
    private float gravity = -9.81f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        characterController.Move(move * Time.deltaTime * speed);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}