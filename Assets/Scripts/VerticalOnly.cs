using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalOnly : MonoBehaviour
{
    private PlayerController playerController;
    private Collider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        if (playerController == null)
        {
            Debug.LogError("PlayerController object missing");
        }
        else
        {
            playerCollider = playerController.gameObject.GetComponent<Collider2D>();
            if (playerCollider == null)
            {
                Debug.LogError("No collider on PlayerController");
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other) // Ha bel�p egy m�sik collider, lefut a script
    {
        Debug.LogError("Something Enter");
        if (playerCollider == other) // Megn�zz�k, hogy a bel�p� collider a player object-e?
        {
            Debug.LogError("Player Enter");
            playerController.verticalOnly = true; // Ha igen, akkor be�ll�tjuk, hogy a karakter csak le f�l tudjon mozogni!
        }
    }

    void OnTriggerExit2D(Collider2D other) // Amikor kil�p, akkor vissza�ll�tjuk az ir�ny�t�st, hogy jobbra ballra is tudjon mazogni
    {
        if (playerCollider == other)
        {
            playerController.verticalOnly = false;
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
