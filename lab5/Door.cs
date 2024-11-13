using UnityEngine;

public class Door : MonoBehaviour
{
    public float angleToOpen = 90f;
    public float rotationSpeed = 2f;
    public Transform playerTransform;

    private bool opening = false;
    private bool closing = false;
    private Quaternion closedState;
    private Quaternion openedState;

    void Start()
    {
        closedState = transform.rotation;
        openedState = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + angleToOpen, transform.rotation.eulerAngles.z);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer < 3f)
        {
            if (!opening)
            {
                StartOpen();
            }
        }
        else
        {
            if (!closing)
            {
                StartClose();
            }
        }

        if (opening)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, openedState, Time.deltaTime * rotationSpeed);

            if (Quaternion.Angle(transform.rotation, openedState) < 1f)
            {
                opening = false;
            }
        }

        if (closing)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, closedState, Time.deltaTime * rotationSpeed);

            if (Quaternion.Angle(transform.rotation, closedState) < 1f)
            {
                closing = false;
            }
        }
    }

    void StartOpen()
    {
        opening = true;
        closing = false;
    }

    void StartClose()
    {
        opening = false;
        closing = true;
    }
}
