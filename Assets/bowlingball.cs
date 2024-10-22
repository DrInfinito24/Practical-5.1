using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlingball : MonoBehaviour
{
    //Variables are made public here so the values can be seen on the inspector for debugging.
    public bool ballThrown = false; //Ensures the thrown force acn only be applied once.
    public float ballPower = 0;//Throwing power
    public float ballSpin = 0;//Ball Torque

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();//Get Rigidbody component.
        float ballPosition = Input.GetAxis("ballPosition");//The position of the ball is controlled by an axis (a = left, d = right).
        rb.AddForce(ballPosition * 2.0f,0.0f,0.0f);//Apply force to the x axis based on the ballPosition axis.
        rb.AddTorque(new Vector3(0.0f,0.0f,ballSpin*2.0f));//Apply torque to the z axis based on the ballSpin variable.
        //Get inputs to increase/decerase values of variables.
        if(Input.GetKey(KeyCode.W)){
            ballPower--;
        }
        else if(Input.GetKey(KeyCode.S)){
            ballPower++;
        }

        else if(Input.GetKey(KeyCode.Q)){
            ballSpin--;
        }
        else if(Input.GetKey(KeyCode.E)){
            ballSpin++;
        }
        else if(Input.GetKey(KeyCode.Space)){
            if(!ballThrown && ballPower != 0){//Only called if the ball has enough power to move. Only called once to prevent being thrown again in the middle of the lane.
                ballThrown = true;
                rb.AddForce(0.0f,0.0f,ballPower*3.0f);//Apply force to the z axis based on the ballPower variable.
            }
        }

    }
}
