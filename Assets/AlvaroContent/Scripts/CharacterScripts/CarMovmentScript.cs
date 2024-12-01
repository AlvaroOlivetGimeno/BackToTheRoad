using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarMovmentScript : MonoBehaviour
{
    [Header("Game Object Attributes")]
    private Rigidbody2D rigidBody2D;

    [Header("Movement Attributes")]
    
    [Range(1.0f, 25.0f)]
    public float carVelocity = 0.0f;
    float currentCarVelocity = 0.0f;

    [Range(0.1f, 5.0f)]
    public float carAcceleration = 0.0f;

    [Range(0.1f, 5.0f)]
    public float carDesAcceleration = 0.0f;

    [Range(1.0f, 25.0f)]
    public float slowDownCarForce = 0.0f;
    bool bSlowingDownCar = false;


    float horizontalAxisValue = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        SlowDownCar();
        MovementFunction();
        //Debug.Log(bSlowingDownCar);
    }
    void FixedUpdate()
    {
       
        rigidBody2D.velocity = new Vector2(horizontalAxisValue * currentCarVelocity, rigidBody2D.velocity.y);
    }

    void MovementFunction()
    {
        if(!bSlowingDownCar)
        {
            if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
            {
                if (horizontalAxisValue == 0)
                {
                    horizontalAxisValue = 1;
                }
                else if (horizontalAxisValue == 1)
                {
                    Acceleration();
                }
                else
                {
                    DesAcceleration();
                }
            }
            else if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.RightArrow))
            {
                if (horizontalAxisValue == 0)
                {
                    horizontalAxisValue = -1;
                }
                else if (horizontalAxisValue == -1)
                {
                    Acceleration();
                }
                else
                {
                    DesAcceleration();
                }
            }
            else
            {
                DesAcceleration();
            }
        }
    }

    public void Acceleration()
    {
        currentCarVelocity += (slowDownCarForce / 100);

        if (currentCarVelocity>=carVelocity)
        {
            currentCarVelocity = carVelocity;
        }
    }

    public void DesAcceleration()
    {
        currentCarVelocity -= (carAcceleration / 100);

        if (currentCarVelocity <= 0)
        {
            horizontalAxisValue = 0;
            currentCarVelocity = 0;
        }
    }

    public void SlowDownCar()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            bSlowingDownCar = true;

            currentCarVelocity -= (carAcceleration / 100);

            if (currentCarVelocity <= 0)
            {
                horizontalAxisValue = 0;
                currentCarVelocity = 0;
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space)) 
        {
            bSlowingDownCar = false;
        
        }
    }

    public float GetHorizontalAxisValue()
    {
        return horizontalAxisValue;
    }
}
