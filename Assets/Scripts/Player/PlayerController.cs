using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed= 1;
    public float turnspeed = 10;
    public float max_speed = 20;
    public GameObject camera;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void UpdateVelocityDirection()
    {
        rigidbody.velocity = transform.forward * transform.InverseTransformDirection(rigidbody.velocity).z;
    }

    void rotateCamera(bool forwards)
    {
        if (forwards)
        {
            camera.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            camera.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.velocity += transform.forward * speed;
            rotateCamera(true);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.velocity += -transform.forward * speed;
            rotateCamera(false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.fixedDeltaTime * turnspeed, Space.World);
            UpdateVelocityDirection();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.fixedDeltaTime * turnspeed, Space.World);
            UpdateVelocityDirection();
        }

        /*if (Input.GetKey(KeyCode.LeftControl))
        {
            //brake
            float current_speed = rigidbody.velocity.magnitude;
            float new_speed=0;
            if (current_speed > 0)
            {
                //going forwards
                if (current_speed > speed)
                {
                    new_speed = current_speed - speed;
                }
                else
                {
                    new_speed = 0;
                }
            }
            else if(current_speed < 0)
            {
                //going backwards
                if(current_speed < -speed)
                {
                    new_speed = current_speed+speed;
                }
                else
                {
                    new_speed = 0;
                }
            }
            else
            {
                new_speed = 0;
            }
            rigidbody.velocity += transform.forward * new_speed; 
        }*/
    }   
}
