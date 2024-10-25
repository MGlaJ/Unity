using UnityEngine;

public class LerpFollower : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 0.1f;

    void Update()
    {
        
        float newPositionY = Mathf.Lerp(transform.position.y, target.position.y, lerpSpeed * Time.deltaTime);

        
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
    }
}
