using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierHP : MonoBehaviour
{
    public int health = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
