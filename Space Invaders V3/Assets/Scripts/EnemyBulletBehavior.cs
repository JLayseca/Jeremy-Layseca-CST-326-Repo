using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : MonoBehaviour
{
    private Rigidbody myRigidbody;

    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
        myRigidbody.velocity = Vector3.down * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
