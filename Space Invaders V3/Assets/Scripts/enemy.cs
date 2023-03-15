using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Vector3 position;
    public float pointValue;
    static bool RightLeftTF = true;
    bool priorChecker = RightLeftTF;
    static float movementTimer = 1f;
    public GameObject bullet;
    private bool canFire = true;

    AudioSource enemyNoise;
    public AudioClip laserSound;
    public AudioClip explosionSound;
    
    public delegate void DeathDelegate(float a);
    public static event DeathDelegate deathEvent;
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemyNoise = GetComponent<AudioSource>();
        position = transform.position;
        InvokeRepeating("EnemyMoveLeftRight", 0f, movementTimer);
        InvokeRepeating("PositionChecker", 0f, movementTimer / 2);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 right = transform.TransformDirection(Vector3.right);
        Debug.DrawRay(transform.position, right, Color.green);
        Vector3 left = transform.TransformDirection(Vector3.left);
        Debug.DrawRay(transform.position, left, Color.red);

        if (priorChecker != RightLeftTF)
        {
            EnemyMoveDown();
            priorChecker = RightLeftTF;
        }
    }

    void EnemyMoveLeftRight()
    {
        YouMayFireWhenReady();
        transform.position = position;
        if (RightLeftTF == true)
            position = new Vector3(position.x + 1f, position.y, position.z);
        
        if (RightLeftTF == false)
            position = new Vector3(position.x - 1f, position.y, position.z);

    }

    void EnemyMoveDown()
    {
        transform.position = position;
        position = new Vector3(position.x, position.y - 2f, position.z);
    }

    void PositionChecker()
    {
        Collider enemyCollider = GetComponent<Collider>();
        var rayLength = enemyCollider.bounds.extents.x * 2;
        RaycastHit boundaryHit;
        
        if (Physics.Raycast(transform.position, Vector3.right, out boundaryHit, rayLength) && RightLeftTF == true)
        {
            if (boundaryHit.collider.tag == "RightBound")
            {
                Debug.Log("Going Left Now");
                RightLeftTF = false;
                
            }

        }

        if (Physics.Raycast(transform.position, Vector3.left, out boundaryHit, rayLength) && RightLeftTF == false)
        {
            if (boundaryHit.collider.tag == "LeftBound")
            {
                Debug.Log("Going Right Now");
                RightLeftTF = true;
                
            }

        }
    }

    void OnCollisionEnter(Collision bullet)
    {
        deathEvent.Invoke(pointValue);
        if (bullet.gameObject.tag == "Bullet")
        {
            canFire = false;
            movementTimer -= 0.1f;
            Debug.Log(pointValue);
            enemyNoise.clip = explosionSound;
            enemyNoise.Play();
            Destroy(gameObject, 3f);
        }
    }

    void YouMayFireWhenReady()
    {
        if (Random.value > 0.97 && canFire == true)
        {
            GameObject Bullet = Instantiate(bullet, position, Quaternion.identity);
            enemyNoise.clip = laserSound;
            enemyNoise.Play();
            Destroy(Bullet, 5f);
        }
    }

}
