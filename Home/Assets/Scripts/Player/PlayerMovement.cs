using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpHeight = 10f;
    public float minJumpThresh = 1f;
    public int numAllowedJumps = 2;
    public static PlayerMovement instance;

    private bool dead = false;

    private Rigidbody rb;

    private float OriginalJumpHeight;
    private bool jumped = false;
    private int jumpCounter = 0;
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

    public void Update()
    {
        if (!dead)
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

            // -- The following code tweaks the physics to make the jump feel better -- //

            // Enhance the fall speed
            if (rb.velocity.y < 0)
                rb.velocity += Physics.gravity * fallMultiplier * Time.deltaTime;

            // Fall faster if player isn't holding the jump button
            if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
                rb.velocity += Physics.gravity * jumpDragMultiplier * Time.deltaTime;
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
