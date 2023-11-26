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

    // Добавьте это поле для хранения ссылки на сферу курсора
    [SerializeField] private GameObject cursorSphere;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;

        // Замораживаем вращение по осям X, Y и Z
        rb.freezeRotation = true;


        // Проверяем, что сфера была найдена
        if (cursorSphere == null)
        {
            Debug.LogError("CursorSphere not found! Make sure it has the correct tag or use another way to find it.");
        }
    }

    void Update()
    {

        HandleMovementInput();
        HandleMouseLook();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
        Debug.Log("Player Position: " + transform.position);
        Debug.Log("Cursor Sphere Position: " + cursorSphere.transform.position);
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
        // Получаем позицию курсора в мировых координатах
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = transform.position.y;

        // Поворачиваем персонажа в сторону курсора
        Vector3 lookDirection = mousePosition - transform.position;
        lookDirection.y = 0f; // Убеждаемся, что вращение происходит только по горизонтали

        if (lookDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}
