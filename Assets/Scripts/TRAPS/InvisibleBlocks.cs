using UnityEngine;

public class InvisibleBlocks : MonoBehaviour
{
    [SerializeField] private GameObject platformVisual; // The actual platform (e.g., a sprite or tilemap)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (platformVisual != null)
                platformVisual.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (platformVisual != null)
                platformVisual.SetActive(false);
        }
    }
}
