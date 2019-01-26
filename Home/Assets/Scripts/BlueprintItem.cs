using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintItem : MonoBehaviour
{
    public Material blueprintMaterial;
    public Material normalMaterial;

    void Start()
    {
        GetComponent<MeshRenderer>().material = blueprintMaterial;
    }

    public void ShowItem()
    {
        GetComponent<MeshRenderer>().material = normalMaterial;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ShowItem();
        }
    }
}
