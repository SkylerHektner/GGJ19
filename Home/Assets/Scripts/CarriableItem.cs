using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriableItem : MonoBehaviour
{
    public Material highlightMaterial;

    private MeshRenderer meshRenderer;
    private GameObject player;
    private bool onHighlight;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = null;
        onHighlight = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (onHighlight)
            {
                gameObject.transform.SetParent(player.transform, true);
                NormalItem();
            }
            else
            {
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
