using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScoreRight : MonoBehaviour
{
    public int RightPoints = 0;
    public int LeftPoints = 0;
    private void OnTriggerEnter(Collider ball)
    {
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        float contactPoint = ball.transform.position.y;

        if (contactPoint > 0)
        {
            RightPoints++;
            Debug.Log($"Right player scored! They have {RightPoints} points!");
            ballBody.transform.position = new Vector3(0, 0, 0);
            ballBody.velocity = Vector3.zero; 
            ballBody.AddForce(Vector3.up * 600f, ForceMode.Force);
        }

        if (contactPoint < 0)
        {
            LeftPoints++;
            Debug.Log($"Left player scored! They have {LeftPoints} points!");
            ballBody.transform.position = new Vector3(0, 0, 0);
            ballBody.velocity = Vector3.zero;
            ballBody.AddForce(Vector3.down * 600f, ForceMode.Force);
        }

        if(RightPoints == 11 || LeftPoints == 11)
        {
            if(RightPoints == 11)
            {
                Debug.Log($"Game Over! Right player wins!");
            }
            else
            {
                Debug.Log($"Game Over! Left player wins!");
            }
            RightPoints = 0;
            LeftPoints = 0;
        }
    }
}
