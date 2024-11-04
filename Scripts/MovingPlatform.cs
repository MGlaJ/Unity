using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 targetPosition; // Celowa pozycja, do której platforma ma siê przesun¹æ
    public float speed = 2f;       // Prêdkoœæ poruszania siê platformy
    private Vector3 startPosition; // Pozycja pocz¹tkowa platformy
    private bool playerOnPlatform; // Czy gracz jest na platformie

    private void Start()
    {
        // Zapisanie pocz¹tkowej pozycji platformy
        startPosition = transform.position;
    }

    private void Update()
    {
        // Je¿eli gracz jest na platformie, przesuwaj j¹ w kierunku celu
        if (playerOnPlatform)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        // Przesuniêcie platformy w kierunku targetPosition
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzenie, czy obiekt, który dotkn¹³ platformy, jest graczem
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true; // Ustawienie flagi, ¿e gracz jest na platformie
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Sprawdzenie, czy obiekt opuszczaj¹cy platformê jest graczem
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false; // Ustawienie flagi, ¿e gracz opuœci³ platformê
            transform.position = startPosition; // Resetowanie pozycji platformy
        }
    }
}
