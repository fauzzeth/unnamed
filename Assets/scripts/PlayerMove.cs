using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;
    [SerializeField] private float speed = 7.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        direction = new Vector3(moveX, 0, moveZ);
        direction = transform.TransformDirection(direction);
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}