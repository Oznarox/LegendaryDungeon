using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum KeyType { Bronze, Silver, Gold }

public class KeyScript : MonoBehaviour
{  
    [SerializeField] KeyType keyType;

    private AudioSource audioSource;
    public AudioClip keyFound;
    private PlayerController playerController;
    private Collider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = FindObjectOfType<PlayerController>();
        playerCollider = playerController.gameObject.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == playerCollider)  //Ha a játékos collidere belép a kulcs trigger colliderébe
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (keyType == KeyType.Bronze)
                playerController.bronzeKeys++;

            if (keyType == KeyType.Silver)
                playerController.silverKeys++;

            if (keyType == KeyType.Gold)
                playerController.goldKeys++;

            audioSource.PlayOneShot(keyFound);
            Destroy(gameObject, keyFound.length);
        }
    }
}
