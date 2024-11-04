using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public float sensitivity = 5f;  // Czu³oœæ obrotu
    public Transform playerBody;    // Odniesienie do cia³a gracza

    private float xRotation = 0f;   // Rotacja kamery wokó³ osi X

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Ukrywanie kursora
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Ograniczenie ruchu w pionie

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  // Ruch kamery góra-dó³
        playerBody.Rotate(Vector3.up * mouseX);  // Ruch cia³a gracza na boki
    }
}
