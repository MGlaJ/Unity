using UnityEngine;
using System.Collections.Generic; 

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; 
    public int numberOfCubes = 10;
    public Vector2 planeSize = new Vector2(10, 10);

    private List<Vector3> usedPositions = new List<Vector3>();

    void Start()
    {
        SpawnCubes();
    }

    void SpawnCubes()
    {
        int cubesSpawned = 0;

        while (cubesSpawned < numberOfCubes)
        {
            
            float xPosition = Random.Range(-planeSize.x / 2, planeSize.x / 2);
            float zPosition = Random.Range(-planeSize.y / 2, planeSize.y / 2);
            Vector3 randomPosition = new Vector3(Mathf.Round(xPosition), 0.5f, Mathf.Round(zPosition));

            
            if (!usedPositions.Contains(randomPosition))
            {
                
                Instantiate(cubePrefab, randomPosition, Quaternion.identity);

                
                usedPositions.Add(randomPosition);
                cubesSpawned++;
            }
        }
    }
}
