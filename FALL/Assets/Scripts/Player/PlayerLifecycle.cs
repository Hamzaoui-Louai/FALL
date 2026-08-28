using UnityEngine;

public class PlayerLifecycle : MonoBehaviour
{
    const float OffscreenerOffset = 6f;
    const float RespawnOffset = 1f;

    PlayerBehaviour behaviour;
    Offscreener offscreener;
    [SerializeField] GameObject gameOverCanvas;

    Vector3 currentCheckpoint;
    bool isDead;
    bool isOffscreened;

    void Awake()
    {
        behaviour = GetComponent<PlayerBehaviour>();
        offscreener = GameObject.Find("Offscreener").GetComponent<Offscreener>();
    }

    public bool IsDead() => isDead;

    public bool IsOffscreened() => isOffscreened;

    public void Respawn()
    {
        isDead = false;
        isOffscreened = false;
        gameOverCanvas.SetActive(false);
        behaviour.SetGravity(5f);
        offscreener.SetOffScreenerYPosition(OffscreenerOffset);
        behaviour.SetPosition(currentCheckpoint + new Vector3(0f, RespawnOffset, 0f));
    }

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
        behaviour.SetGravity(0f);
        offscreener.SetOffScreenerYPosition(behaviour.GetPosition().y + OffscreenerOffset);
    }

    public void OffscreenPlayer()
    {
        isDead = true;
        isOffscreened = true;
        behaviour.SetGravity(0f);
        if (!gameOverCanvas.activeSelf)
            gameOverCanvas.SetActive(true);
    }
}