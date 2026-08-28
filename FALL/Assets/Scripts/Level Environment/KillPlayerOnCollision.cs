using UnityEngine;

public class KillPlayerOnCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerLifecycle>().KillPlayer();
    }
}