using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootingOffset;
    public float acceleration = 4f;
    private int health = 3;
    private Animator playerAnimator;

    AudioSource playerNoise;
    public AudioClip laserSound;
    public AudioClip explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerNoise = GetComponent<AudioSource>();
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
                playerAnimator.SetTrigger("ShootTrigger");
                GameObject Bullet = Instantiate(bullet,shootingOffset.position, Quaternion.identity);
                Debug.Log("Shot Fired!");
                playerNoise.clip = laserSound;
                playerNoise.Play();
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
            {
                playerNoise.clip = explosionSound;
                playerNoise.Play();
                playerAnimator.SetTrigger("UhOh");
                Destroy(gameObject, 2f);
            }
        }
    }
}
