using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = Mathf.Max(0, value); } // Ensure moveSpeed is not negative
    }

    public float AscendSpeed
    {
        get { return ascendSpeed; }
        set { ascendSpeed = Mathf.Max(0, value); } // Ensure ascendSpeed is not negative
    }

    public float DescendSpeed
    {
        get { return descendSpeed; }
        set { descendSpeed = Mathf.Max(0, value); } // Ensure descendSpeed is not negative
    }

    public float RotationSpeed
    {
        get { return rotationSpeed; }
        set { rotationSpeed = Mathf.Max(0, value); } // Ensure rotationSpeed is not negative
    }

    private Rigidbody rb;
    public float moveSpeed = 5.0f, ascendSpeed = 2.0f, descendSpeed = 2.0f, rotationSpeed = 0.001f;

    private float mouseX; // Mouse X movement
    private float mouseY; // Mouse Y movement

    public bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
            mouseX += Input.GetAxis("Mouse X");
            mouseY -= Input.GetAxis("Mouse Y");
            mouseY = Mathf.Clamp(mouseY, -90f, 90f); // Clamp vertical rotation to avoid flipping

            // Rotate the player object based on mouse movement
            transform.rotation = Quaternion.Euler(0f, mouseX, 0f);
        if(canMove) 
        {

            // Rotate the camera object based on mouse movement
            Camera.main.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0f);

            // Get the direction from the player's rotation
            Vector3 moveDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
            Debug.Log("Get Axis: " + Input.GetAxis("Horizontal"));

            // Update the Rigidbody velocity only in FixedUpdate
            rb.velocity = moveDirection.normalized * MoveSpeed;
        }
       
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            bool ascend = Input.GetKey(KeyCode.LeftShift), descend = Input.GetKey(KeyCode.Space);

            float xRotation = 0;

            if (ascend)
            {
                rb.velocity += Vector3.up * AscendSpeed;
                xRotation = -45;
            }
            else if (descend)
            {
                rb.velocity += Vector3.down * DescendSpeed;
                xRotation = 45;
            }

            // Update the rotation in FixedUpdate
            if (rb.velocity != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(rb.velocity);
                targetRotation *= Quaternion.Euler(xRotation, 0, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
            }
            else
            {
                Quaternion targetRotation = Quaternion.Euler(xRotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
            }
        }
       
    }

    // Function to quit the game
    public void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Call the QuitGame function in Update

}
