using UnityEngine;

public class FakeShortcutBomb : MonoBehaviour
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private LayerMask LayertoHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
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
