using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float moveSpeed = 3f;

    private bool isPlayerOn = false;
    private bool movingToEnd = true;

    void Update()
    {
        if (isPlayerOn)
        {
            MoveBetweenPoints();
        }
    }

    void MoveBetweenPoints()
    {
        Transform target = movingToEnd ? end : start;
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (transform.position == target.position)
        {
            movingToEnd = !movingToEnd;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOn = true;
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOn = false;
            other.transform.parent = null;
        }
    }
}
