using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnCollide : MonoBehaviour
{
    public Transform targetPos;
    
    public Vector3 targetFacing;
    public float facingErrorThresh;

    private AudioSource[] sounds;

    private void Awake()
    {
        sounds = GetComponents<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            PlayerLook l = collision.collider.gameObject.GetComponent<PlayerLook>();
            if ((l.currentFacingDirection - targetFacing).sqrMagnitude < facingErrorThresh)
            {
                collision.gameObject.transform.position = targetPos.position;
                if (sounds != null)
                {
                    sounds[0].Play();
                    sounds[1].Play();
                }
            }
        }
    }
}
