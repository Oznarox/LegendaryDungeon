using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteOnTrigger : MonoBehaviour
{
    public Sprite newSprite;

    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the object.");
        }

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
            spriteRenderer.sprite = newSprite;
        }
    }
}