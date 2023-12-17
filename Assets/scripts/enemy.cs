using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private Canvas deathCanvas; // Canvas that displays the death message

    private Rigidbody rb;
    private PlayerController playerController; // Assuming the player has a PlayerController script

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        deathCanvas.enabled = false; // Make sure the death canvas is not visible at the start
        playerController = player.GetComponent<PlayerController>(); // Get the PlayerController script
    }

    private void Update()
    {
        // Rotate to face the player
        transform.LookAt(player.transform);

        // Move towards the player
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the enemy has collided with the player
        if (collision.gameObject == player)
        {
            // Disable the player's control
            playerController.enabled = false;

            // Make the player fall
            Rigidbody playerRb = player.GetComponent<Rigidbody>();
            playerRb.useGravity = true;

            // Unfreeze all rotations
            playerRb.constraints = RigidbodyConstraints.None;

            // Display the death canvas
            deathCanvas.enabled = true;
        }
    }
}
