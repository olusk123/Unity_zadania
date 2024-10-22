using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    public float speed = 2f; 
    public float sideLength = 10f; 
    private Vector3[] corners; 
    private int currentCorner = 0; 
    public Transform arrowIndicator;

    void Start()
    {
        Vector3 startPosition = transform.position;
        corners = new Vector3[4];
        corners[0] = startPosition; 
        corners[1] = startPosition + new Vector3(sideLength, 0, 0); 
        corners[2] = corners[1] + new Vector3(0, 0, sideLength); 
        corners[3] = startPosition + new Vector3(0, 0, sideLength); 
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, corners[currentCorner], step);

        if (Vector3.Distance(transform.position, corners[currentCorner]) < 0.01f)
        {
            Turn(-90); 
            currentCorner = (currentCorner + 1) % 4; 
        }
        arrowIndicator.rotation = transform.rotation;
    }

    void Turn(float angle)
    {
        transform.Rotate(0, angle, 0);
    }
}