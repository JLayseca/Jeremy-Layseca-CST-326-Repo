using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class myCharacterController : MonoBehaviour
{
    public float acceleration = 10f;
    public float maxSpeed;
    public float shiftMaxSpeed;
    public float jumpForce = 10f;
    public float gravity;
    private Color lineColor;
    public bool onGround;
    public bool casting;
    public float jumpBoost = 5f;
    private float baseSpeed;
    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI scoreCount;
    public TextMeshProUGUI countDown;
    public TextMeshProUGUI victoryMessage;
    private int coins = 0;
    private int score = 0;
    private float halfHeight;
    private float startingBoost;
    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = maxSpeed;
        startingBoost = jumpBoost;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rbody = GetComponent<Rigidbody>();
        if(Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            rbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.Space))
        {

            rbody.AddForce(Vector3.up * jumpBoost, ForceMode.Force);
            jumpBoost -= gravity;
            if (jumpBoost < (-0.7f * startingBoost)){
                jumpBoost = -0.7f * startingBoost;
            }
        }
        
        float speed = rbody.velocity.magnitude;
        bool grounded = onGround;
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("Speed", speed);
        animator.SetBool("grounded", onGround);

    }

    void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        Rigidbody rbody = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.LeftShift)){
            maxSpeed = shiftMaxSpeed;
        }
        else{
            maxSpeed = baseSpeed;
        }
        
        
        rbody.velocity += horizontalAxis * Vector3.right * Time.deltaTime * acceleration;;
        
        Collider col = GetComponent<Collider>();
        var heightForJump = 0.2f;
        var heightForBreak = col.bounds.extents.y * 2 + 0.3f;
        
        //if(rbody.mag)
        //{
            //rbody.velocity = Vector3.ClampMagnitude(rbody.velocity, maxSpeed);
        //}

        onGround = Physics.Raycast(transform.position, Vector3.down, heightForJump);

        rbody.velocity = new Vector3(Mathf.Clamp(rbody.velocity.x, -maxSpeed, maxSpeed), rbody.velocity.y, rbody.velocity.z);

        
        if (onGround)
        {
            lineColor = Color.green;
            casting = true;
            jumpBoost = startingBoost;
        }
        else
        {
            lineColor = Color.red;
        }
            Debug.DrawLine(transform.position, transform.position + Vector3.down * halfHeight, lineColor, 0f, false);

        

        RaycastHit blockHit;

        //blockHit = Physics.Raycast(transform.position, Vector3.up, halfHeight);

        if (Physics.Raycast(transform.position, Vector3.up, out blockHit, heightForBreak) && casting == true){
            if (blockHit.collider.tag == "Breakable"){
                    GameObject hitBlock = blockHit.collider.gameObject;
                    Destroy(hitBlock);

                    score += 100;
                    if (score < 1000){
                         scoreCount.text = $"Mario \nX000{score}";
                    }
                    if (score >= 1000){
                         scoreCount.text = $"Mario \nX00{score}";
                    }
                    if (score >= 10000){
                         scoreCount.text = $"Mario \nX0{score}";
                    }
                    if (score >= 100000){
                         scoreCount.text = $"Mario \nX{score}";
                    }
                }

                if (blockHit.transform.tag == "CoinGiver"){
                    coins++;
                    if (coins < 10){
                         coinCount.text = $"Coins \nX0{coins}";
                    }
                    if (coins >= 10){
                    coinCount.text = $"Coins \nX{coins}";
                    }
                    if (coins == 100){
                        coins = 0;
                        coinCount.text = $"Coins \nX0{coins}";
                    }

                    score += 200;
                    if (score < 1000){
                         scoreCount.text = $"Mario \nX000{score}";
                    }
                    if (score >= 1000){
                         scoreCount.text = $"Mario \nX00{score}";
                    }
                    if (score >= 10000){
                         scoreCount.text = $"Mario \nX0{score}";
                    }
                    if (score >= 100000){
                         scoreCount.text = $"Mario \nX{score}";
                    }
                }

            casting = false;
        }

        if (Physics.Raycast(transform.position, Vector3.right, out blockHit, 0.4f)){
            if (blockHit.transform.tag == "Goal"){
                    Destroy(countDown);
                    victoryMessage.text = $"You win!";
                }
        }
    }

}