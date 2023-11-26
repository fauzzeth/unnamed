using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject cursorSphere;

    void Start()
    {
        if (cursorSphere == null)
        {
            Debug.LogError("CursorSphere is not assigned in the Inspector!");
            return;
        }

        // Проверяем наличие компонента Rigidbody перед получением
        Rigidbody sphereRigidbody = cursorSphere.GetComponent<Rigidbody>();
        if (sphereRigidbody != null)
        {
            // Замораживаем вращение по осям X, Y и Z
            sphereRigidbody.freezeRotation = true;
        }

        // Устанавливаем начальное местоположение сферы на место игрока
        cursorSphere.transform.position = transform.position;
        cursorSphere.SetActive(false);
    }

    void Update()
    {
        MoveCursorToMouse();
        cursorSphere.SetActive(true); // Убедитесь, что объект активирован
    }


    private void MoveCursorToMouse()
    {
        // Получаем позицию курсора в мировых координатах
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = transform.position.y;

        // Устанавливаем позицию сферы курсора на место курсора
        cursorSphere.transform.position = mousePosition;
    }
}
