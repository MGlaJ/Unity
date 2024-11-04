using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform leftOpenPosition;   // Pozycja otwartych drzwi w lewo
    public Transform rightOpenPosition;  // Pozycja otwartych drzwi w prawo
    public float openingSpeed = 2f;      // Prêdkoœæ otwierania drzwi
    private Vector3 closedPosition;      // Pozycja zamkniêtych drzwi
    private bool isPlayerNearLeft;       // Czy gracz jest blisko lewej strony drzwi
    private bool isPlayerNearRight;      // Czy gracz jest blisko prawej strony drzwi

    private void Start()
    {
        closedPosition = transform.position; // Zapamiêtaj pozycjê zamkniêtych drzwi
    }

    private void Update()
    {
        // Otwórz drzwi w lewo, jeœli gracz jest blisko lewej strony
        if (isPlayerNearLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftOpenPosition.position, openingSpeed * Time.deltaTime);
        }
        // Otwórz drzwi w prawo, jeœli gracz jest blisko prawej strony
        else if (isPlayerNearRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightOpenPosition.position, openingSpeed * Time.deltaTime);
        }
        // Jeœli gracza nie ma, drzwi wracaj¹ do pozycji zamkniêtej
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, openingSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 playerPosition = other.transform.position;

            // SprawdŸ, czy gracz jest bli¿ej lewej lub prawej strony drzwi
            isPlayerNearLeft = playerPosition.x < transform.position.x;
            isPlayerNearRight = playerPosition.x > transform.position.x;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Gdy gracz opuœci strefê, resetuj flagi
            isPlayerNearLeft = false;
            isPlayerNearRight = false;
        }
    }
}
