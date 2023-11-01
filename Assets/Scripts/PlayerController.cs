using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject goalTriggerObject;
    public GameObject InstructionTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    public float moveSpeed = 5.0f;
    public Transform playerCamera;  // Reference to the third-person camera

// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
        goalTriggerObject.SetActive(false);
        InstructionTextObject.SetActive(true);

    }

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

    /*void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }*/

    //sets the text counting the collectibles in the top-left corner
    void SetCountText()
    {
        countText.text = "Collected: " + count.ToString() + "/12";

        if(count >= 12)
        {
            InstructionTextObject.SetActive(false);
            winTextObject.SetActive(true);
            goalTriggerObject.SetActive(true);
        }
    }

   /* void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    } 
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }

}
