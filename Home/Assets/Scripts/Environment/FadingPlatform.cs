using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPlatform : MonoBehaviour
{
    public float duration;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            FadeOut();
        }
    }

    private void FadeOut()
    {
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        for (float f = 1f; f >= 0; f -= 1 / duration)
        {
            Color c = meshRenderer.material.color;
            c.a = f;
            meshRenderer.material.color = c;
            yield return null;
        }
        Destroy(gameObject);
    }
}
