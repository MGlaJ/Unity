using UnityEngine;
using System.Collections.Generic;

public class MovingPlatform2 : MonoBehaviour
{
    public List<Vector3> waypoints;       // Lista punkt�w docelowych
    public float speed = 2f;              // Pr�dko�� poruszania si� platformy
    private int currentWaypointIndex = 0; // Aktualny indeks punktu docelowego
    private bool goingForward = true;     // Flaga okre�laj�ca kierunek ruchu

    private void Update()
    {
        if (waypoints.Count < 2)
        {
            Debug.LogWarning("Potrzebne s� co najmniej dwa punkty w li�cie waypoints.");
            return;
        }

        MovePlatform();
    }

    private void MovePlatform()
    {
        // Pobierz aktualny punkt docelowy
        Vector3 targetPosition = waypoints[currentWaypointIndex];

        // Przesu� platform� w kierunku punktu docelowego
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Sprawd�, czy platforma dotar�a do punktu docelowego
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Zaktualizuj indeks punktu docelowego
            if (goingForward)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Count)
                {
                    currentWaypointIndex -= 2; // Przejd� do przedostatniego punktu
                    goingForward = false;      // Zmie� kierunek na wstecz
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1; // Przejd� do drugiego punktu
                    goingForward = true;      // Zmie� kierunek na prz�d
                }
            }
        }
    }
}
