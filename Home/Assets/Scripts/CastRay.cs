using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastRay : MonoBehaviour
{
    private GameObject hitCarryableItem;
    private float rayDistance = 2.0f;
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            CarriableItem cit;
            cit = hit.transform.gameObject.GetComponent<CarriableItem>();
            if (cit != null)
            {
                if (hitCarryableItem != null && hitCarryableItem != cit.transform.gameObject)
                {
                    hitCarryableItem.GetComponent<CarriableItem>().NormalItem();
                }
                hitCarryableItem = cit.transform.gameObject;
                cit.HighlightItem();
            }
        }
        else
        {
            if (hitCarryableItem != null)
            {
                hitCarryableItem.GetComponent<CarriableItem>().NormalItem();
                hitCarryableItem = null;
            }
        }
    }
}
