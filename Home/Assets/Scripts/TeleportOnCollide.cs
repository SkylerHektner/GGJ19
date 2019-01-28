using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnCollide : MonoBehaviour
{
    public Transform targetPos;
    
    public Vector3 targetFacing;
    public float facingErrorThresh;

    private AudioSource sound;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            PlayerLook l = collision.collider.gameObject.GetComponent<PlayerLook>();
            if ((l.currentFacingDirection - targetFacing).sqrMagnitude < facingErrorThresh)
            {
                collision.gameObject.transform.position = targetPos.position;
                sound.Play();
                PlayerMovement.instance.SwitchBGM();
            }
        }
    }
}
