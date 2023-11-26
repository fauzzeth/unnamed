using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset = new Vector3(0f, 2f, -5f);  

    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + offset;

            transform.LookAt(playerTransform.position);
        }
    }
}
