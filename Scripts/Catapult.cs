using UnityEngine;

public class Catapult : MonoBehaviour
{
    public float launchForceMultiplier = 3f;  // Mno�nik si�y wyrzutu
    private void OnTriggerEnter(Collider other)
    {
        // Sprawd�, czy gracz wszed� na p�yt�
        if (other.CompareTag("Player"))
        {
            // Pobierz Rigidbody gracza
            Rigidbody playerRb = other.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                // Ustal pr�dko�� skoku gracza (mo�na zmodyfikowa�)
                float playerJumpForce = 5f; // Przyk�adowa warto�� skoku gracza

                // Oblicz si�� wyrzutu
                float launchForce = playerJumpForce * launchForceMultiplier;

                // Wyrzu� gracza w powietrze, dodaj�c si�� w kierunku Y
                playerRb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
            }
        }
    }
}
