using System.Collections;
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
    public Vector3 relativeVelocity;

    private bool dead = false;

    private Rigidbody rb;
    private AudioSource[] audios;
    private AudioSource stepSound1;
    private AudioSource stepSound2;
    private AudioSource jumpSound;
    private AudioSource pickupSound;

    private float OriginalJumpHeight;
    private int jumpCounter = 0;
    private bool jumped = false;
    private bool shouldFall = false;
    private bool grounded = false;
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
        audios = GetComponents<AudioSource>();
        stepSound1 = audios[0];
        stepSound2 = audios[1];
        jumpSound = audios[2];
        pickupSound = audios[3];
        relativeVelocity = Vector3.zero;
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

            rb.velocity = movement * Speed + new Vector3(0, rb.velocity.y, 0) + relativeVelocity; 
            // rb.MovePosition(movement * Speed * Time.fixedDeltaTime + transform.position);

            if (grounded)
            {
                if (movement.magnitude > 0.5 && !stepSound1.isPlaying && !stepSound2.isPlaying)
                {
                    stepSound1.volume = Random.Range(0.05f, 0.07f);
                    stepSound1.pitch = Random.Range(1.3f, 1.5f);
                    stepSound1.Play();
                } 
            }
            else
            {
                if (jumpCounter == 0)
                {
                    jumpCounter++;
                }
            }

            // Reset Jump Counter if player hits the floor
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, minJumpThresh))
            {
                if (!grounded)
                {
                    grounded = true;
                    if (rb.velocity.y < 0)
                        stepSound2.Play();
                }
                
                jumpCounter = 0;
            }
            else
            {
                grounded = false;
            }

            // Check if player is trying to jump
            if (jumped)
            {
                jumped = false;
                if (jumpCounter < numAllowedJumps)
                {
                    jumpSound.Play();
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

    public void PlayPickUpSound()
    {
        pickupSound.Play();
    }
}
