using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random : MonoBehaviour
{
    public int numberOfObjects = 10;
    public float delay = 3.0f;
    private int objectCounter = 0;

    public GameObject Cube;

    public Material[] materials;

    private List<Vector3> positions = new List<Vector3>();
    private Bounds platformBounds = 0;

    void Start()
    {
        platformBounds = GetComponent<Renderer>().bounds;

        Random();

        StartCoroutine(GenerateObject());
    }

    void Random()
    {
        List<float> posX = new List<float>(Enumerable.Range(0, 20)
            .Select(i => Random.Range(platformBounds.min.x, platformBounds.max.x))
            .Take(numberOfObjects));

        List<float> posZ = new List<float>(Enumerable.Range(0, 20)
            .Select(i => Random.Range(platformBounds.min.z, platformBounds.max.z))
            .Take(numberOfObjects));

        for (int i = 0; i < numberOfObjects; i++)
        {
            positions.Add(new Vector3(posX[i], platformBounds.max.y + 1, posZ[i]));
        }
    }

    IEnumerator GenerateObject()
    {
        foreach (Vector3 pos in positions)
        {
            GameObject Cube = Instantiate(Cube, pos, Quaternion.identity);

            Material randomMaterial = materials[Random.Range(0, materials.Length)];
            Cube.GetComponent<Renderer>().material = randomMaterial;

            yield return new WaitForSeconds(delay);
        }
    }
}