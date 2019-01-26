using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Vector3 lastCheckpoint;
    CanvasGroup canvasGroup;
    public float fadeDuration;
    public float stayBlackDuration;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        lastCheckpoint = PlayerMovement.instance.transform.position;
    }

    public void PlayDeathTransition()
    {
        PlayerMovement.instance.ResetDead();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        for (float f = 0; f <= 1f; f += 1 / fadeDuration)
        {
            canvasGroup.alpha = f;
            yield return null;
        }
        canvasGroup.alpha = 1f;
        PlayerMovement.instance.transform.position = lastCheckpoint;
        StartCoroutine(StayBlack());
    }

    IEnumerator StayBlack()
    {
        for (float f = 0; f <= 1f; f += 1 / stayBlackDuration)
        {
            yield return null;
        }
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        for (float f = 1f; f >= 0; f -= 1 / fadeDuration)
        {
            canvasGroup.alpha = f;
            yield return null;
        }
        canvasGroup.alpha = 0;
        PlayerMovement.instance.ResetDead();
    }

    public void UpdateCheckpoint(Vector3 point)
    {
        lastCheckpoint = point;
    }
}
