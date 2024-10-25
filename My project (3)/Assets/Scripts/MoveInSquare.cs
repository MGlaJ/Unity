using UnityEngine;

public class MoveInSquare : MonoBehaviour
{
    public float speed = 2.0f; 
    public GameObject directionIndicator; 

    private Vector3[] corners; 
    private int currentCorner = 0; 

    void Start()
    {
        
        Vector3 startPos = transform.position;
        corners = new Vector3[]
        {
            startPos, 
            startPos + new Vector3(10f, 0f, 0f), 
            startPos + new Vector3(10f, 0f, 10f),
            startPos + new Vector3(0f, 0f, 10f)
        };
    }

    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, corners[currentCorner], speed * Time.deltaTime);

        
        if (transform.position == corners[currentCorner])
        {
            
            transform.Rotate(0, 90f, 0);

            
            currentCorner = (currentCorner + 1) % corners.Length;
        }

        
        if (directionIndicator != null)
        {
            directionIndicator.transform.position = transform.position;
            directionIndicator.transform.rotation = transform.rotation; 
        }
    }
}
