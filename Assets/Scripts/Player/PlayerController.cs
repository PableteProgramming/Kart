using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private bool ctrl;
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

        if (Input.GetKey("space"))
        {
            if (ctrl)
            {
                transform.position += -transform.forward * speed * Time.deltaTime;
            }
            else
            {
                // move forwards
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
    }
}
