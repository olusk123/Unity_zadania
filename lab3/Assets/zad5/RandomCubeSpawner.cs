using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; 
    public int numberOfCubes = 10;
    public float planeSize = 10f; 

    private HashSet<Vector3> occupiedPositions = new HashSet<Vector3>();

    void Start()
    {
        SpawnCubes();
    }

    void SpawnCubes()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition = GetRandomPosition();

            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 position;
        do
        {
            float x = Random.Range(-planeSize / 2f, planeSize / 2f);
            float z = Random.Range(-planeSize / 2f, planeSize / 2f);
            position = new Vector3(x, 0.5f, z); 
        } while (occupiedPositions.Contains(position)); 

        occupiedPositions.Add(position); 
        return position;
    }
}
