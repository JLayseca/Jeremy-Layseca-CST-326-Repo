using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootingOffset;
    public float acceleration = 4f;
    private int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (GameObject.Find("Bullet(Clone)") != null)
            {
                Debug.Log("We're still reloading!");
            }
            else
            {
                GameObject Bullet = Instantiate(bullet,shootingOffset.position, Quaternion.identity);
                Debug.Log("Shot Fired!");
                Destroy(Bullet, 3f);
            }
        }
    }

    void FixedUpdate()
    {
        float RightLeftVal = Input.GetAxis("Horizontal");
        Rigidbody playerBody = GetComponent<Rigidbody>();
        
        playerBody.velocity += RightLeftVal * Vector3.right * Time.deltaTime * acceleration;
    }

    void OnCollisionEnter(Collision bullet)
    {
        if (bullet.gameObject.tag == "Bullet")
        {
            health--;
            if (health == 0)
                Destroy(gameObject);
        }
    }
}
