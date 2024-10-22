using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeX : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    private float moveDistance = 10f;
    private bool movingForward = true;
    private float startPositionX;

    void Start()
    {
        startPositionX = transform.position.x;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        if (movingForward)
        {
            transform.Translate(step, 0, 0);
            if (transform.position.x >= startPositionX + moveDistance)
                movingForward = false;
        }
        else
        {
            transform.Translate(-step, 0, 0);
            if (transform.position.x <= startPositionX)
                movingForward = true;
        }
    }
}
