using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriableItem : MonoBehaviour
{
    public Material highlightMaterial;

    private MeshRenderer meshRenderer;
    private GameObject camera;
    private Rigidbody rb;
    private bool onHighlight;
    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        meshRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        meshRenderer.material = null;
        onHighlight = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (onHighlight)
            {
                gameObject.transform.position = new Vector3(0, 0, 1.5f);
                gameObject.transform.SetParent(camera.transform, false);
                rb.isKinematic = true;
                rb.detectCollisions = false;
                NormalItem();
            }
            else
            {
                rb.isKinematic = false;
                rb.detectCollisions = true;
                gameObject.transform.parent = null;
            }
        }
    }
    public void HighlightItem()
    {
        meshRenderer.material = highlightMaterial;
        onHighlight = true;
    }

    public void NormalItem()
    {
        meshRenderer.material = null;
        onHighlight = false;
    }
}
