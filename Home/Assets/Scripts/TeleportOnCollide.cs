using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnCollide : MonoBehaviour
{
    public Transform targetPos;
    private AudioSource levelSound;

    private void Awake()
    {
        levelSound = GetComponent<AudioSource>();
    }

    public Vector3 targetFacing;
    public float facingErrorThresh;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            PlayerLook l = collision.collider.gameObject.GetComponent<PlayerLook>();
            if ((l.currentFacingDirection - targetFacing).sqrMagnitude < facingErrorThresh)
            {
                levelSound.Play();
                collision.gameObject.transform.position = targetPos.position;
            }
        }
    }
}
