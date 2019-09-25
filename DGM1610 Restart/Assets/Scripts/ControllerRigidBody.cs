﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]

public class ControllerRigidBody : MonoBehaviour
{

    private Vector3 pos;
    
    public int jumpCount;

    public int jumpCountMax = 2;
    
    public LayerMask groundLayers;

    public CapsuleCollider capsule;
    
    private string moveInputAxis = "Vertical";
    
    private string turnInputAxis = "Horizontal";

    public float rotationRate = 360f;
    
    public float moveSpeed = 10f;

    public float jumpSpeed = 10f;

    public float gravity = 9.81f;
    
    

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    
    {
        
        pos.y -= gravity;
        
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);
        

        ApplyInput(moveAxis, turnAxis);
        
        
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && jumpCount < jumpCountMax)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
     
            jumpCount++;
        }

        
    }

    private bool IsGrounded()
    {
        jumpCount = 0;
        
        return Physics.CheckCapsule(capsule.bounds.center,
            new Vector3(capsule.bounds.center.x, capsule.bounds.min.y, capsule.bounds.center.z), capsule.radius * .9f, groundLayers);
        
    }





    private void ApplyInput(float moveInput, float turnInput)
    {
        Move(moveInput);
        Turn(turnInput);
    }


    private void Move(float input)
    {
        rb.AddForce(moveSpeed * input * transform.forward, ForceMode.Force);
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
    

}



