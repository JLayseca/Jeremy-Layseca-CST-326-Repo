using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public float ballSpeed = 600;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody ballBody = GetComponent<Rigidbody>();
        ballBody.AddForce(Vector3.down * ballSpeed, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
