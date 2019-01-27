using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnCollide : MonoBehaviour
{
    public GameObject[] objToDisable;

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            foreach(GameObject g in objToDisable)
            {
                g.SetActive(false);
            }
        }
    }
}
