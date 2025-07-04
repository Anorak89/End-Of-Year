﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_PlugScript : MonoBehaviour
{
    [Tooltip("Feature for one using only")]
    public bool OneTime = false;
    
    [Tooltip("Plug follow this local EmptyObject")]
    public Transform HeroHandsPosition;
    
    [Tooltip("SocketObject with collider(shpere, box etc.) (is trigger = true)")]
    public Collider Socket; // should be a Trigger

    public AN_DoorScript DoorObject;

    float distance;
    float angleView;
    Vector3 direction;

    bool follow = false, isConnected = false, followFlag = false, youCan = true;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (youCan) Interaction();

        if (isConnected)
        {
            // Snap to socket
            transform.position = Socket.transform.position;
            transform.rotation = Socket.transform.rotation;

            // Open the door
            DoorObject.isOpened = true;
        }
        else
        {
            DoorObject.isOpened = false;
        }
    }

    void Interaction()
    {
        if (NearView() && Input.GetKeyDown(KeyCode.E) && !follow)
        {
            isConnected = false;
            follow = true;
            followFlag = false;
        }

        if (follow)
        {
            rb.linearDamping = 10f;
            rb.angularDamping = 10f;

            if (followFlag)
            {
                distance = Vector3.Distance(transform.position, Camera.main.transform.position);
                if (distance > 3f || Input.GetKeyDown(KeyCode.E))
                {
                    follow = false;
                }
            }

            followFlag = true;
            rb.AddExplosionForce(-1000f, HeroHandsPosition.position, 10f);
        }
        else
        {
            rb.linearDamping = 0f;
            rb.angularDamping = 0.5f;
        }
    }

    bool NearView()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        return (distance < 3f && angleView < 35f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == Socket)
        {
            isConnected = true;
            follow = false;

            // Remove this line: DoorObject.rbDoor.AddRelativeTorque(new Vector3(0, 0, 20f));

            if (OneTime) youCan = false;
        }
    }
}
