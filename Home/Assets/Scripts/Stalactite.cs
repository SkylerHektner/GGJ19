using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour, ITriggerable
{
    [SerializeField] private Transform particleEffect;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    
    void Update()
    {
        
    }

    public void Activate()
    {
        rb.isKinematic = false;
    }

    // When it hits the ground.
    private void OnCollisionEnter(Collision c)
    {
        rb.isKinematic = true;
        Instantiate(particleEffect, transform.position, Quaternion.identity);
    }
}
