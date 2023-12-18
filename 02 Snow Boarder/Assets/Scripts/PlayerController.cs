using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 10;

    float normalSpeed = 50f;
    float boostSpeed = 100f;

    bool canControl = true;

    Rigidbody2D rigidBody2d; 
    SurfaceEffector2D surfaceEffector2d;

    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        surfaceEffector2d = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canControl == true)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canControl = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2d.speed = boostSpeed;
        }

        else
        {
            surfaceEffector2d.speed = normalSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody2d.AddTorque(torqueAmount);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody2d.AddTorque(-torqueAmount);
        }
    }
}
