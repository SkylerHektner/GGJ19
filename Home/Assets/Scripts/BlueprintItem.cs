using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintItem : MonoBehaviour
{
    public Material blueprintMaterial;
    public Material normalMaterial;
    public Material highlightMaterial;

    public string itemName;

    private MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.material = blueprintMaterial;
    }

    public void ShowItem()
    {
        if(meshRenderer != null)
            meshRenderer.material = normalMaterial;
    }

    public void HighlightItem()
    {
        if(meshRenderer != null)
            meshRenderer.material = highlightMaterial;
    }

    public void CancelHighlightItem()
    {
        if(meshRenderer != null)
            meshRenderer.material = blueprintMaterial;
    }
}
