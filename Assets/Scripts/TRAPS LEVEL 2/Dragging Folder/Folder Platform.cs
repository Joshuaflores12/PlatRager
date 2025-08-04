using UnityEngine;
using System.Collections;

public class FolderPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minMoveTime;
    [SerializeField] private float maxMoveTime;

    private bool playerOnPlatform = false;
    private int direction = 1;
    private Coroutine moveRoutine;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerOnPlatform = true;

            direction = Random.value > 0.5f ? 1 : -1;

            if (moveRoutine == null)
                moveRoutine = StartCoroutine(MoveAndSwitchDirection());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerOnPlatform = false;
            if (moveRoutine != null)
            {
                StopCoroutine(moveRoutine);
                moveRoutine = null;
            }
        }
    }

    private IEnumerator MoveAndSwitchDirection()
    {
        while (playerOnPlatform)
        {
            float moveDuration = Random.Range(minMoveTime, maxMoveTime);
            float timer = 0f;

            while (timer < moveDuration && playerOnPlatform)
            {
                transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
                timer += Time.deltaTime;
                yield return null;
            }

            direction *= -1;
        }
    }
}
