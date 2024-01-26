using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class silverkey : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip keyFound;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Ha a játékos belép
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            playerController.silverKeys++;
            audioSource.PlayOneShot(keyFound);
            Destroy(gameObject, keyFound.length);
        }
    }


}
