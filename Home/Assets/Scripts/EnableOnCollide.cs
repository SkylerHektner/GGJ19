using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnCollide : MonoBehaviour
{
    public GameObject[] objToEnable;

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            foreach (GameObject g in objToEnable)
            {
                g.SetActive(true);
            }
        }
    }
}
