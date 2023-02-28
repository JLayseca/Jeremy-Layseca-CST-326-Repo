using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCollision : MonoBehaviour
{
    public Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = GameObject.Find("Mario").transform.position;;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider mario){
        Rigidbody player = mario.GetComponent<Rigidbody>();
        player.transform.position = startingPosition;
    } 
}
