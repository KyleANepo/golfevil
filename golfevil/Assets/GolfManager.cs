using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfManager : MonoBehaviour
{
    // manage the actual game stuffs
    public golfball ball;

    // 0 inactive, 1 angle, 2 power, 3 ball launched, 4 ball in air (ze turn cannot be reset until ball is still)
    private int turnState = 0;

    void Update()
    {
        UpdateTurn();
    }

    private void UpdateTurn()
    {
        // Debug.Log(turnState);
        if (Input.GetKeyDown(KeyCode.Space) && turnState <= 4)
        {
            turnState = turnState + 1;
        } else if (Input.GetKeyDown(KeyCode.Space) && turnState > 4)
        {
            turnState = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetBall();
        // Reset after landing    
    }

    private void SetBall()
    {
        // Get angle, Get power, Launch ball

        if (turnState == 1)
        {
            GetAngle();
        }
        else if (turnState == 2)
        {
            GetPower();
        }
        else if (turnState == 3)
        {
            LaunchBall();
            turnState += 1;
            // turnState = 0;
        }
        Debug.Log(turnState);
    }

    // angle of ball
    float angle = 0.0f;
    bool angleToggle = false;
    float tempo = 2.0f;

    // get the angle of the ball based on player input
    // -90.0f is max low
    private void GetAngle()
    {
        if (angle == 0.0f && angleToggle == false)
        {
            angleToggle = true;
        }
        else if (angle == -90.0f && angleToggle == true)
        {
            angleToggle = false;
        }

        if (angleToggle)
        {
            angle -= tempo;
        }
        else
        {
            angle += tempo;
        }

        ball.RotateBall(angle);
    }

    float power = 0.0f;
    bool powerToggle = false;
    float powerTempo = 10.0f;

    // get the power of the hit
    private void GetPower()
    {
        if (power == 0.0f && powerToggle == false)
        {
            powerToggle = true;
        }
        else if (power == 500.0f && powerToggle == true)
        {
            powerToggle = false;
        }

        if (powerToggle)
        {
            power += powerTempo;
        }
        else
        {
            power -= powerTempo;
        }

        Debug.Log(power);
    }

    private void LaunchBall()
    {
        ball.Launch(power);
    }

    private void ResetBall()
    {
        
    }
}
