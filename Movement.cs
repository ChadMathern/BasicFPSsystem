﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/Movement Input")]
public class Movement : MonoBehaviour
{
    public float speed = 15.0f;
    public float gravity = -9.8f;
    //public Rigidbody MyRigidBody;
    private float JumpForce = 20.0f;
    private float verticalVelocity;

    private Vector3 moveDirection = Vector3.zero;

    private CharacterController _charController;

    void Start()
    {
        //MyRigidBody = GetComponent<Rigidbody>();
        _charController = GetComponent<CharacterController>();
    }

    void Update() { 
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;
        

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);

        if (Input.GetButtonDown("Jump") && _charController.isGrounded)
            {
            verticalVelocity = JumpForce;
            }
        

     
        Vector3 jumpVector = new Vector3(0, verticalVelocity , 0);
        _charController.Move(jumpVector * Time.deltaTime);
        //verticalVelocity = gravity * Time.deltaTime;
    }

}

