using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{

    public float unitsPerSec = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float ForwardBackVal = Input.GetAxis("Horizontal");
        Vector3 paddleForce = Vector3.forward * ForwardBackVal * unitsPerSec;

        Rigidbody appliedForce = GetComponent<Rigidbody>();
        appliedForce.AddForce(paddleForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter (Collision collision)
    {
        Debug.Log($"We've been hit by a {collision.gameObject.name}, sir!");

        //paddle collider ref
        BoxCollider box = GetComponent<BoxCollider>();

        float contactPoint = collision.transform.position.z;
        
        float bounceAngle = 60f * contactPoint / 2.5f;

        Quaternion rotation = Quaternion.Euler(bounceAngle, 0f, 0f);
        Vector3 bounceDirection = rotation * Vector3.up;

        Rigidbody rb = collision.rigidbody;
        rb.AddForce(bounceDirection * 1000f, ForceMode.Force);
    }
}
