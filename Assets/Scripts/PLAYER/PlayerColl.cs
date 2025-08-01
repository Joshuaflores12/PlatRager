using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerColl : MonoBehaviour
{
    public static Vector3 savedRespawnPoint;
    [SerializeField] private Transform respawnSpawnPoint;
    [SerializeField] private Rigidbody2D rb;


    private void Awake()
    {
        if (savedRespawnPoint == Vector3.zero) 
        {
            savedRespawnPoint = respawnSpawnPoint.position;
        }

        transform.position = savedRespawnPoint;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die() 
    {
        Debug.Log("Player Died!");
        rb.linearVelocity = Vector2.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public static void SetCheckpoint(Vector3 newCheckpoint) 
    {
        savedRespawnPoint = newCheckpoint;
    }

}