

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    public static SpawnPoint LatestSpawnPoint;

    // private static Dictionary<int, SpawnPoint> spawnPoints = new Dictionary<int, SpawnPoint>();

    [SerializeField] public int SpawnPointID;
    private PlayerController playerController; // ez �gy szar, van jobb megold�s, de egyel�re j�vanez�gy
    private Collider2D playerCollider;

    private void Awake()
    {
        LatestSpawnPoint = this;

    }
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();       //GetComponent<PlayerController>();
        if (playerController == null ) 
        {
            Debug.LogError("No PlayerController in scene");
        }
        else playerCollider = playerController.gameObject.GetComponent<Collider2D>();
        if (playerCollider == null )
        {
            Debug.LogError("No Collider2D on PlayerController object");
        }

    }

    public Vector3 GetSpawnPointPosition() // Visszaadja az objektum pozici�j�t a t�rben
    {
        return transform.position;
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if ( collision == playerCollider )
        {
            playerController.verticalOnly = false;
            playerController.horizontalOnly = false;
        }
    }
    void OnTriggerExit2D (Collider2D collision)
    {
        if (collision == playerCollider)
        {
            playerController.verticalOnly = false;
            playerController.horizontalOnly = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}


