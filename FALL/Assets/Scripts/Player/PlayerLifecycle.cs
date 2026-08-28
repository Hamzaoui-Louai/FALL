using UnityEngine;

public class PlayerLifecycle : MonoBehaviour
{
    const float OffscreenerOffset = 6f;

    PlayerBehaviour behaviour;
    Offscreener offscreener;

    Vector3 currentCheckpoint;
    bool isDead;

    void Awake()
    {
        behaviour = GetComponent<PlayerBehaviour>();
        offscreener = GameObject.Find("Offscreener").GetComponent<Offscreener>();
    }

    public bool IsDead() => isDead;

    public void SetCheckpoint(GameObject checkpoint)
    {
        currentCheckpoint = checkpoint.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
            SetCheckpoint(collision.gameObject);
    }

    public void KillPlayer()
    {
        isDead = true;
        offscreener.SetOffScreenerYPosition(behaviour.GetPosition().y + OffscreenerOffset);
    }

    public void OffscreenPlayer()
    {
        isDead = true;
    }
}