using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;            // Pr�dko�� ruchu gracza
    public float mouseSensitivity = 100f; // Czu�o�� myszki
    public Transform cameraTransform;   // Transform kamery
    private float xRotation = 0f;

    private void Start()
    {
        // Ukrywa kursor i blokuje go na �rodku ekranu
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        MovePlayer();
        LookAround();
    }

    private void MovePlayer()
    {
        // Odczytaj wej�cia poziome i pionowe
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Przek�ada wej�cia na wektor ruchu
        Vector3 direction = transform.right * horizontal + transform.forward * vertical;
        controller.Move(direction * speed * Time.deltaTime);
    }

    private void LookAround()
    {
        // Pobierz dane z ruchu myszy
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Obracanie kamery w pionie
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Ograniczenie k�ta patrzenia w pionie
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Obracanie gracza w poziomie
        transform.Rotate(Vector3.up * mouseX);
    }
}
