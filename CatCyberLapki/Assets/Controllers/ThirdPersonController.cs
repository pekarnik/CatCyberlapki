using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5.0f;

    Vector3 moveDirection;
    public Transform playerCamera;
    public float cameraHeight = 5;

    // Start is called before the first frame update
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Vertical");
        float moveZ = Input.GetAxisRaw("Horizontal");

        moveDirection = new Vector3(moveX, 0 , -moveZ).normalized;
    }

    void Move()
    {
        Vector3 movePosition = rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;
        playerCamera.transform.position = new Vector3(movePosition.x, cameraHeight, movePosition.z);
        rb.MovePosition(movePosition);
    }
}
