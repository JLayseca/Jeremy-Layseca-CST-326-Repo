using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle2 : MonoBehaviour
{

    public float unitsPerSec = 20f;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        float ForwardBackVal = Input.GetAxis("Vertical");
        Vector3 paddleForce = Vector3.forward * ForwardBackVal * unitsPerSec;

        Rigidbody appliedForce = GetComponent<Rigidbody>();
        appliedForce.AddForce(paddleForce);
    }


    private void OnCollisionEnter (Collision ball)
    {
        Debug.Log($"We've been hit by a {ball.gameObject.name}, sir!");

        //paddle collider ref
        BoxCollider box = GetComponent<BoxCollider>();

        float contactPoint = ball.transform.position.z;
        
        float bounceAngle = 60f * contactPoint / 2.5f;

        Quaternion rotation = Quaternion.Euler(bounceAngle, 0f, 0f);
        Vector3 bounceDirection = rotation * Vector3.down;

        Rigidbody rb = ball.rigidbody;
        rb.AddForce(bounceDirection * 1000f, ForceMode.Force);
    }
}
