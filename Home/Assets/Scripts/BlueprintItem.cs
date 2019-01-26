using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintItem : MonoBehaviour
{
    public Material blueprintMaterial;
    public Material normalMaterial;
    public Material highlightMaterial;

    public string itemName;
    void Start()
    {
        GetComponent<MeshRenderer>().material = blueprintMaterial;
    }

    public void ShowItem()
    {
        GetComponent<MeshRenderer>().material = normalMaterial;
    }

    public void HighlightItem()
    {
        GetComponent<MeshRenderer>().material = highlightMaterial;
    }

    public void CancelHighlightItem()
    {
        GetComponent<MeshRenderer>().material = blueprintMaterial;
    }
}
