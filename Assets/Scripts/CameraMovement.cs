using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private float speedH = 2f;
    private float speedV = 2f;

    private float yaw = 0f;
    private float pitch = 0f;
    Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch += speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch * -1f, yaw, 0f);

        if (Input.GetAxis("Vertical") != 0)
        {
            var rotation = new Quaternion(_rb.rotation.x, transform.rotation.y, _rb.rotation.z, transform.rotation.w);
            _rb.rotation = rotation.normalized;
        }


    }
}
