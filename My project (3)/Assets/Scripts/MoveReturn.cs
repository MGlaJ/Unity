using UnityEngine;

public class MoveAndReturn : MonoBehaviour
{
    public float speed = 2.0f; 
    private Vector3 startPosition; 
    private Vector3 targetPosition; 
    private bool isMovingToTarget = true; 

    void Start()
    {
        
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(10f, 0f, 0f);
    }

    void Update()
    {
        
        Vector3 target = isMovingToTarget ? targetPosition : startPosition;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
        {
            isMovingToTarget = !isMovingToTarget;
        }
    }
}
