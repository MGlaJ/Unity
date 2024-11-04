using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform leftOpenPosition;   // Pozycja otwartych drzwi w lewo
    public Transform rightOpenPosition;  // Pozycja otwartych drzwi w prawo
    public float openingSpeed = 2f;      // Pr�dko�� otwierania drzwi
    private Vector3 closedPosition;      // Pozycja zamkni�tych drzwi
    private bool isPlayerNearLeft;       // Czy gracz jest blisko lewej strony drzwi
    private bool isPlayerNearRight;      // Czy gracz jest blisko prawej strony drzwi

    private void Start()
    {
        closedPosition = transform.position; // Zapami�taj pozycj� zamkni�tych drzwi
    }

    private void Update()
    {
        // Otw�rz drzwi w lewo, je�li gracz jest blisko lewej strony
        if (isPlayerNearLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftOpenPosition.position, openingSpeed * Time.deltaTime);
        }
        // Otw�rz drzwi w prawo, je�li gracz jest blisko prawej strony
        else if (isPlayerNearRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightOpenPosition.position, openingSpeed * Time.deltaTime);
        }
        // Je�li gracza nie ma, drzwi wracaj� do pozycji zamkni�tej
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

            // Sprawd�, czy gracz jest bli�ej lewej lub prawej strony drzwi
            isPlayerNearLeft = playerPosition.x < transform.position.x;
            isPlayerNearRight = playerPosition.x > transform.position.x;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Gdy gracz opu�ci stref�, resetuj flagi
            isPlayerNearLeft = false;
            isPlayerNearRight = false;
        }
    }
}
