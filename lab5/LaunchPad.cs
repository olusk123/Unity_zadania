using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    public float force = 30f;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 upwardVelocity = Vector3.up * force;
                rb.velocity = upwardVelocity;
                Debug.Log("Player zostal wybity w gore!");
            }
        }
    }
}