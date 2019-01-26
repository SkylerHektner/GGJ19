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

//=======
//    public Material highlightMaterial;

//    private MeshRenderer meshRenderer;
//    private GameObject camera;
//    private Rigidbody rb;
//    private bool onHighlight;
//    private void Start()
//    {
//        camera = GameObject.FindGameObjectWithTag("MainCamera");
//        meshRenderer = GetComponent<MeshRenderer>();
//        rb = GetComponent<Rigidbody>();
//        meshRenderer.material = null;
//        onHighlight = false;
//    }
//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            if (onHighlight)
//            {
//                gameObject.transform.position = new Vector3(0, 0, 1.5f);
//                gameObject.transform.SetParent(camera.transform, false);
//                rb.isKinematic = true;
//                rb.detectCollisions = false;
//                NormalItem();
//            }
//            else
//            {
//                rb.isKinematic = false;
//                rb.detectCollisions = true;
//                gameObject.transform.parent = null;
//            }
//        }
//>>>>>>> e85f9cba5ea9bab068b8e624aae8aa47431ffa6c
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
