using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportUtility : MonoBehaviour
{

    public GameObject toTP;
    public GameObject dest;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {            
            toTP.transform.position = dest.transform.position;
            toTP.transform.forward = dest.transform.forward;
            toTP.GetComponent<MimicMovement>().RecalcOffsets();
        }
    }
}
