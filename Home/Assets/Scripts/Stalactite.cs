using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour, ITriggerable
{
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
}
