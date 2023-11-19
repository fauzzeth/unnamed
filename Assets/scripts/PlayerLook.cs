using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float mouseSense = 1;

    [SerializeField] private float minVert = -80; // Top
    [SerializeField] private float maxVert = 70; // Botm

    private float rotateX;
    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main;
		Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotateX -= Input.GetAxis("Mouse Y") * mouseSense;
        rotateX = Mathf.Clamp(rotateX, minVert, maxVert);

        Vector3 rotPlayerCamera = playerCamera.transform.rotation.eulerAngles;
        rotPlayerCamera.x = rotateX;

        playerCamera.transform.rotation = Quaternion.Euler(rotPlayerCamera);

        float rotateY = Input.GetAxis("Mouse X") * mouseSense;
        Vector3 rotPlayer = transform.rotation.eulerAngles;
        rotPlayer.y += rotateY;
        transform.rotation = Quaternion.Euler(rotPlayer);
    }
}