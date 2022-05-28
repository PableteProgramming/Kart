using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject follow_obj;
    private float init_x;
    private float init_z;
    private float init_y;

    void Start()
    {
        init_x = transform.position.x;
        init_z = transform.position.z;
        init_y = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(follow_obj.transform.position.x + init_x, follow_obj.transform.position.y + init_y, follow_obj.transform.position.z + init_z);
    }
}
