using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 targetPosition; // Celowa pozycja, do kt�rej platforma ma si� przesun��
    public float speed = 2f;       // Pr�dko�� poruszania si� platformy
    private Vector3 startPosition; // Pozycja pocz�tkowa platformy
    private bool playerOnPlatform; // Czy gracz jest na platformie

    private void Start()
    {
        // Zapisanie pocz�tkowej pozycji platformy
        startPosition = transform.position;
    }

    private void Update()
    {
        // Je�eli gracz jest na platformie, przesuwaj j� w kierunku celu
        if (playerOnPlatform)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        // Przesuni�cie platformy w kierunku targetPosition
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzenie, czy obiekt, kt�ry dotkn�� platformy, jest graczem
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true; // Ustawienie flagi, �e gracz jest na platformie
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Sprawdzenie, czy obiekt opuszczaj�cy platform� jest graczem
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false; // Ustawienie flagi, �e gracz opu�ci� platform�
            transform.position = startPosition; // Resetowanie pozycji platformy
        }
    }
}
