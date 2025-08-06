using UnityEngine;

public class InspectorGlitch : MonoBehaviour
{
    [SerializeField] private GameObject Inspector;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            Inspector.transform.eulerAngles = new Vector3(0f, 0f, 90f);
        }
    }
}
