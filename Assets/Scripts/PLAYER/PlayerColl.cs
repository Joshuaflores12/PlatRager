using UnityEngine;

public class PlayerColl : MonoBehaviour
{
    [SerializeField] private Transform respawnSpawnPoint;
    [SerializeField] private Rigidbody2D rb;

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
        transform.position = respawnSpawnPoint.position;

    }

}