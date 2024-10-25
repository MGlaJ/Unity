using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    public int objectCount = 10;
    public float delay = 3.0f;
    public GameObject block;
    public List<Material> materials;
    private List<Vector3> positions = new List<Vector3>();

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Bounds bounds = renderer.bounds;

        List<int> positionsX = new List<int>(Enumerable.Range((int)bounds.min.x, (int)bounds.size.x).OrderBy(x => Guid.NewGuid()).Take(objectCount));
        List<int> positionsZ = new List<int>(Enumerable.Range((int)bounds.min.z, (int)bounds.size.z).OrderBy(x => Guid.NewGuid()).Take(objectCount));

        for (int i = 0; i < objectCount; i++)
        {
            positions.Add(new Vector3(positionsX[i], 5, positionsZ[i]));
        }

        StartCoroutine(GenerujObiekt());
    }

    IEnumerator GenerujObiekt()
    {
        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(block, pos, Quaternion.identity);
            Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Count)];
            newBlock.GetComponent<Renderer>().material = randomMaterial;
            yield return new WaitForSeconds(delay);
        }
    }
}
