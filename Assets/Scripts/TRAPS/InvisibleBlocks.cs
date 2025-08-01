using UnityEngine;

public class InvisibleBlocks : MonoBehaviour
{
    [SerializeField] private SpriteRenderer invisibleBlock;
    private void Start()
    {
        if (invisibleBlock != null)
        {
            SetAlpha(0f); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && invisibleBlock != null)
        {
            SetAlpha(1f); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && invisibleBlock != null)
        {
            SetAlpha(0f); 
        }
    }

    private void SetAlpha(float alpha)
    {
        Color color = invisibleBlock.color;
        color.a = alpha;
        invisibleBlock.color = color;
    }
}
