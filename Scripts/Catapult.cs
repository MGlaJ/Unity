using UnityEngine;

public class Catapult : MonoBehaviour
{
    public float launchForceMultiplier = 3f;  // Mno¿nik si³y wyrzutu
    private void OnTriggerEnter(Collider other)
    {
        // SprawdŸ, czy gracz wszed³ na p³ytê
        if (other.CompareTag("Player"))
        {
            // Pobierz Rigidbody gracza
            Rigidbody playerRb = other.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                // Ustal prêdkoœæ skoku gracza (mo¿na zmodyfikowaæ)
                float playerJumpForce = 5f; // Przyk³adowa wartoœæ skoku gracza

                // Oblicz si³ê wyrzutu
                float launchForce = playerJumpForce * launchForceMultiplier;

                // Wyrzuæ gracza w powietrze, dodaj¹c si³ê w kierunku Y
                playerRb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
            }
        }
    }
}
