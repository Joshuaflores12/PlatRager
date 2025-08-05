using UnityEngine;

public class FakeShortcutBomb : MonoBehaviour
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private LayerMask LayertoHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            Explode();
            Destroy(gameObject);
        }
    }

    private void Explode() 
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, explosionRadius, LayertoHit);   
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
