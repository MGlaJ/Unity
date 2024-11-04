using UnityEngine;

public class PlayerObstacleDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Sprawd�, czy obiekt, z kt�rym dosz�o do kolizji, ma tag "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Gracz rozpocz�� kontakt z przeszkod�!");
        }
    }
}
