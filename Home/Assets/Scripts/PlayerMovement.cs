﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpHeight = 10f;
    public float minJumpThresh = 1f;
    public int numAllowedJumps = 2;

    private Rigidbody rb;

    private bool jumped = false;
    private int jumpCounter = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {

        // Movement
        Vector3 right = transform.right;
        right.y = 0;
        right.Normalize();
        Vector3 forward = transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 movement = right * Input.GetAxis("Horizontal") + forward * Input.GetAxis("Vertical");

        rb.MovePosition(movement * Speed * Time.deltaTime + transform.position);


        // Reset Jump Counter if player hits the floor
        RaycastHit hitInfo;
        if (jumpCounter != 0 && Physics.Raycast(transform.position, Vector3.down, out hitInfo) &&
            (hitInfo.point - transform.position).magnitude < minJumpThresh)
        {
            jumpCounter = 0;
        }

        // Check if player is trying to jump
        if (!float.Equals(Input.GetAxis("Jump"), 0f))
        {
            if (jumpCounter < numAllowedJumps && !jumped)
            {
                jumped = true;
                jumpCounter += 1;
                Vector3 curVel = rb.velocity;
                curVel.x = 0;
                curVel.z = 0;
                rb.AddForce(Vector3.up * JumpHeight + -curVel, ForceMode.VelocityChange);
                Debug.Log("JUMPING");
            }
        }
        else
        {
            jumped = false;
        }
    }
}
