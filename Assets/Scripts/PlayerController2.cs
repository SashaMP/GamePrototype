using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Transform playerCamera;  // Reference to the third-person camera

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = playerCamera.forward * verticalInput + playerCamera.right * horizontalInput;
        moveDirection.y = 0;  // Ensure the character stays on the flat plane

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection.normalized;
            transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
        }
    }
}
