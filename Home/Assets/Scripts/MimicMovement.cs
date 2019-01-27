using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicMovement : MonoBehaviour
{
    public Transform target;

    private Vector3 rotOffset;
    private Vector3 posOffset;
    // Start is called before the first frame update
    void Start()
    {
        rotOffset = transform.rotation.eulerAngles - target.rotation.eulerAngles;
        posOffset = transform.position - target.position;
    }

    public void RecalcOffsets()
    {
        rotOffset = transform.rotation.eulerAngles - target.rotation.eulerAngles;
        posOffset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + posOffset;
        transform.rotation = Quaternion.Euler(target.rotation.eulerAngles + rotOffset);
    }
}
