using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteAlpha : MonoBehaviour
{
    public float targetAlpha = 0.0f;
    public float fadeDuration = 1.0f;

    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;
    private float originalAlpha;
    private float currentAlpha;
    private float fadeStartTime;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the object.");
        }

        originalAlpha = spriteRenderer.color.a;
        currentAlpha = originalAlpha;

        playerController = FindObjectOfType<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController object could not be found.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() == playerController)
        {
            fadeStartTime = Time.time;
            StartCoroutine(FadeSprite());
        }
    }
    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() == playerController)
        {
            StopAllCoroutines();
            currentAlpha = originalAlpha;
            Color newColor = spriteRenderer.color;
            newColor.a = currentAlpha;
            spriteRenderer.color = newColor;
        }
    }*/

    private IEnumerator FadeSprite()
    {
        while (currentAlpha > targetAlpha)
        {
            float fadeProgress = (Time.time - fadeStartTime) / fadeDuration;
            currentAlpha = Mathf.Lerp(originalAlpha, targetAlpha, fadeProgress);

            Color newColor = spriteRenderer.color;
            newColor.a = currentAlpha;
            spriteRenderer.color = newColor;

            yield return null;
        }
    }
}