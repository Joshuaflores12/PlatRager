using UnityEngine;

public class SceneViewBlocker : MonoBehaviour
{
    [SerializeField] private GameObject hiddenBlock;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            hiddenBlock.SetActive(true);
        }
    }
}
