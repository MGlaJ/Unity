using UnityEngine;
using System.Collections.Generic;

public class MovingPlatform2 : MonoBehaviour
{
    public List<Vector3> waypoints;       // Lista punktów docelowych
    public float speed = 2f;              // Prêdkoœæ poruszania siê platformy
    private int currentWaypointIndex = 0; // Aktualny indeks punktu docelowego
    private bool goingForward = true;     // Flaga okreœlaj¹ca kierunek ruchu

    private void Update()
    {
        if (waypoints.Count < 2)
        {
            Debug.LogWarning("Potrzebne s¹ co najmniej dwa punkty w liœcie waypoints.");
            return;
        }

        MovePlatform();
    }

    private void MovePlatform()
    {
        // Pobierz aktualny punkt docelowy
        Vector3 targetPosition = waypoints[currentWaypointIndex];

        // Przesuñ platformê w kierunku punktu docelowego
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // SprawdŸ, czy platforma dotar³a do punktu docelowego
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Zaktualizuj indeks punktu docelowego
            if (goingForward)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Count)
                {
                    currentWaypointIndex -= 2; // PrzejdŸ do przedostatniego punktu
                    goingForward = false;      // Zmieñ kierunek na wstecz
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1; // PrzejdŸ do drugiego punktu
                    goingForward = true;      // Zmieñ kierunek na przód
                }
            }
        }
    }
}
