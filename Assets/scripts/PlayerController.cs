using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float shiftSpeed = 10f;
    [SerializeField] float jumpForce = 7f;

    private bool isGrounded;
    private float currentSpeed;
    private Rigidbody rb;
    private Vector3 direction;

    [SerializeField] private GameObject cursorSphere;
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private GameObject walls;

    void Start()
    {
        walls.SetActive(true);
        rb = GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;
        rb.freezeRotation = true;


    }

    void Update()
    {
        HandleMovementInput();
        HandleMouseLook();
        UpdateCameraPosition();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void HandleMovementInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        direction = new Vector3(moveX, 0, moveZ);
        direction = transform.TransformDirection(direction);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = shiftSpeed;
        }
        else
        {
            currentSpeed = movementSpeed;
        }
    }

    private void HandleMouseLook()
    {
        if (cursorSphere != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.y = transform.position.y;

            Vector3 lookDirection = mousePosition - transform.position;
            lookDirection.y = 0f;
            float angle = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
    private void UpdateCameraPosition()
    {
        if (cameraTransform != null)
        {
            cameraTransform.position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        }
    }
}
