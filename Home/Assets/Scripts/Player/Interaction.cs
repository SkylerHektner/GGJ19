using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject cam;
    public float interactionDistance = 3f;

    private bool carrying = false;

    private CarriableItem curCandidate;

    private float offsetMagnitude;

    // Update is called once per frame
    void Update()
    {
        if (!carrying)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, interactionDistance)
                    && hitInfo.collider.tag == "Carryable")
            { 
                curCandidate = hitInfo.collider.gameObject.GetComponent<CarriableItem>();
                curCandidate.HighlightItem();
                if (Input.GetButtonDown("Interact"))
                {
                    offsetMagnitude = (curCandidate.transform.position - cam.transform.position).magnitude;
                    curCandidate.rb.useGravity = false;
                    carrying = true;
                }
            }
            else if (curCandidate != null)
            {
                curCandidate.NormalItem();
                curCandidate = null;
            }
        }
        else
        {
            Vector3 targetPos = cam.transform.position + cam.transform.forward * offsetMagnitude;
            curCandidate.rb.velocity = (targetPos - curCandidate.transform.position) * 20f;
            if (Input.GetButtonDown("Interact"))
            {
                carrying = false;
                curCandidate.rb.useGravity = true;
            }
        }
    }
}
