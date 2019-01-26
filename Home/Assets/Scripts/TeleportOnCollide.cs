using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnCollide : MonoBehaviour
{
    public Transform targetPos;
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = targetPos.position;
    }
}
