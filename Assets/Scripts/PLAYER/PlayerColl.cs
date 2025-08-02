using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayerColl : MonoBehaviour
{
    public static Vector3 savedRespawnPoint;
    [SerializeField] private Transform respawnSpawnPoint;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float deathDelay = 0.5f;



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
    private IEnumerator DelayedDeath()
    {
        Debug.Log("Player Died!");
        rb.linearVelocity = Vector2.zero;

        FadeManager.Instance.FadeOut();

        yield return new WaitForSeconds(deathDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            StartCoroutine(DelayedDeath());
        }
    }

    public static void SetCheckpoint(Vector3 newCheckpoint) 
    {
        savedRespawnPoint = newCheckpoint;
    }

}