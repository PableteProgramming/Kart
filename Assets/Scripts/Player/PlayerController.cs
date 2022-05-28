using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private bool ctrl;
    public Rigidbody rigidbody;
    private bool alt;
    // Start is called before the first frame update
    void Start()
    {
        ctrl = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            ctrl = true;
        }
        else
        {
            ctrl = false;
        }

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            alt = true;
        }
        else
        {
            alt = false;
        }

        if (Input.GetKey("space"))
        {
            if (ctrl)
            {
                rigidbody.velocity += new Vector3(0,0,-speed);
            }
            else
            {
                // move forwards
                rigidbody.velocity += new Vector3(0, 0, speed);
            }
        }
        else
        {
            if (alt)
            {
                //brake
                float currentvel = rigidbody.velocity.z;

                if(Math.Abs(currentvel) >= speed)
                {
                    if (currentvel > 0)
                    {
                        currentvel = speed;
                    }
                    else
                    {
                        currentvel = -speed;
                    }
                }
                rigidbody.velocity += new Vector3(0, 0, -currentvel);
            }
        }
    }
}
