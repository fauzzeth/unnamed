using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            player.LookAt(new Vector3(hit.point.x, player.position.y, hit.point.z));
        }
    }
}