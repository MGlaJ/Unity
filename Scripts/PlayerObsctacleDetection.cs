using UnityEngine;

public class PlayerObstacleDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // SprawdŸ, czy obiekt, z którym dosz³o do kolizji, ma tag "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Gracz rozpocz¹³ kontakt z przeszkod¹!");
        }
    }
}
