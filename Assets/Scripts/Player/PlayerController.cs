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
    public float brake_speed = 0.8f;

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

    void Brake()
    {
        //brake
        float vel = transform.InverseTransformDirection(rigidbody.velocity).z;
        if (vel != 0) //if moving
        {
            float new_speed = 0;
            if (vel < 0 && vel < -brake_speed) //if moving backwards
            {
                new_speed = vel + brake_speed;
            }
            else if (vel > 0 && vel > brake_speed)
            {
                new_speed = vel - brake_speed;
            }
            rigidbody.velocity = transform.forward * new_speed;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftControl))
        {
            rigidbody.velocity += transform.forward * speed;
            rotateCamera(true);
        }
        
        if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftControl))
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

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Brake();
        }
    }   
}
