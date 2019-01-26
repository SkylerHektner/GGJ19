using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float power;

    // simple version
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerMovement.instance.ChangeJumpHeight(power);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerMovement.instance.ResetJumpHeight();
        }
    }
    // dumb buggy thing written by a drunk guy
    /*
    // private PlayerMovement playerMovement;
    private Rigidbody rigidBody;
    public GameObject player;
    public float power;

    private void Awake()
    {
        rigidBody = player.GetComponent<Rigidbody>();
        // playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x,
                Mathf.Max(power + rigidBody.velocity.y, rigidBody.velocity.y),
                rigidBody.velocity.z);
            rigidBody.velocity += transform.up * power;
        }
    }
    */
}
