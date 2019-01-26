﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpHeight = 10f;
    public float minJumpThresh = 0.55f;
    public int numAllowedJumps = 2;
    public static PlayerMovement instance;
    public GameObject cam;

    private bool dead = false;

    private Rigidbody rb;

    private float OriginalJumpHeight;
    private int jumpCounter = 0;
    private bool jumped = false;
    private bool shouldFall = false;
    private float h;
    private float v;
    private float fallMultiplier = 1.5f; // Makes the player fall faster.
    private float jumpDragMultiplier = 0.8f;

    private void Awake()
    {
        // singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        OriginalJumpHeight = JumpHeight;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumped = true;
        }

        shouldFall = !Input.GetButton("Jump");

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    public void FixedUpdate()
    {
        if (!dead)
        {
            // Movement
            Vector3 right = cam.transform.right;
            right.y = 0;
            right.Normalize();
            Vector3 forward = cam.transform.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 movement = right * h + forward * v;

            rb.MovePosition(movement * Speed * Time.fixedDeltaTime + transform.position);


            // Reset Jump Counter if player hits the floor
            RaycastHit hitInfo;
            if (jumpCounter != 0 && Physics.Raycast(transform.position, Vector3.down, out hitInfo, minJumpThresh))
            {
                jumpCounter = 0;
            }

            // Check if player is trying to jump
            if (jumped)
            {
                jumped = false;
                Debug.Log(jumpCounter);
                if (jumpCounter < numAllowedJumps)
                {
                    jumpCounter += 1;
                    Vector3 curVel = rb.velocity;
                    curVel.x = 0;
                    curVel.z = 0;
                    if (curVel.y > 0)
                    {
                        curVel.y = 0;
                    }
                    rb.AddForce(Vector3.up * JumpHeight + -curVel, ForceMode.VelocityChange);
                }
            }

            // -- The following code tweaks the physics to make the jump feel better -- //

            // Enhance the fall speed
            if (rb.velocity.y < 0)
                rb.velocity += Physics.gravity * fallMultiplier * Time.fixedDeltaTime;

            // Fall faster if player isn't holding the jump button
            if (rb.velocity.y > 0 && shouldFall)
                rb.velocity += Physics.gravity * jumpDragMultiplier * Time.fixedDeltaTime;
        }
    }

    public void ChangeJumpHeight(float factor)
    {
        JumpHeight *= factor;
    }

    public void ResetJumpHeight()
    {
        JumpHeight = OriginalJumpHeight;
    }

    public void ResetDead()
    {
        dead = !dead;
        rb.isKinematic = !rb.isKinematic;
    }
}
