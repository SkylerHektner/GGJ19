using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriableItem : MonoBehaviour
{
    private Material mat;
    public Rigidbody rb;
    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

    }
    public void HighlightItem()
    {
        mat.SetFloat("_FrezPower", 8f);
    }

    public void NormalItem()
    {
        mat.SetFloat("_FrezPower", 0f);
    }
}
