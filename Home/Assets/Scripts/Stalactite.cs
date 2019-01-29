using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour, ITriggerable
{
    [SerializeField] private Transform particleEffect;
    private Rigidbody rb;
    private bool particlesActivated;

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
        if(c.gameObject.tag == "Lava" && !particlesActivated)
        {
            Debug.Log("SETTING KINEMATIC");
            particlesActivated = true;
            Debug.Log("HIT");
            rb.isKinematic = true;
            Transform particles = Instantiate(particleEffect, transform.position, Quaternion.identity);

            // Scale the particles to the size of the stalactite.
            particles.parent = transform;
            particles.localScale = Vector3.one * 0.25f;
        }
    }
}
