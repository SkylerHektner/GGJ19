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
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = blueprintMaterial;
    }

    public void ShowItem()
    {
        meshRenderer.material = normalMaterial;
    }

    public void HighlightItem()
    {
        meshRenderer.material = highlightMaterial;
    }

    public void CancelHighlightItem()
    {
        meshRenderer.material = blueprintMaterial;
    }
}
