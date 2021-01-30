﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private float speedH = 2f;
    private float speedV = 2f;

    private float yaw = 0f;
    private float pitch = 0f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch += speedV * Input.GetAxis("Mouse Y");

        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, yaw, 0) * Time.deltaTime);

        transform.eulerAngles = new Vector3(pitch * -1f, yaw, 0f);
        if (Input.GetAxis("Vertical") > 0)
        {
            var rotation = Quaternion.Euler(new Vector3(transform.rotation.y, 0, 0) * Time.deltaTime);
            rb.MoveRotation(rotation * deltaRotation);
        }
    }
}