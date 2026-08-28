using Newtonsoft.Json.Serialization;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Offscreener : MonoBehaviour
{
    Transform transform;

    Transform playerTransform;

    [SerializeField] float speed = 1f;

    float pauseTimer = 0f;

    const float FrameRate = 60f;
    void Start()
    {
        transform = GetComponent<Transform>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if(IsPaused())
        {
            TickPauseTimer();
        }
        else
        {
            SeekPlayer();
        }
    }

    public void PauseOffscreener(int pauseDuration) //duration is in secondes while pause timer ticks per frame 
    {
        pauseTimer = pauseDuration * FrameRate;
    }

    public void SetOffscreenerSpeed(float newOffScreenerSpeed)
    {
        speed = newOffScreenerSpeed;
    }

    public void SetOffScreenerYPosition(float newOffscreenerYPosition)
    {
        transform.position = new Vector2(0, newOffscreenerYPosition);
    }

    void TickPauseTimer()
    {
        pauseTimer--;
    }

    bool IsPaused()
    {
        return pauseTimer > 0;
    }

    void SeekPlayer()
    {
        if(ReachedPlayer())
        {
            //game over
        }
        else
        {
            transform.position = new Vector2(0, transform.position.y - speed / FrameRate);
        }
    }

    bool ReachedPlayer()
    {
        const float OffscreenerOffset = 7.4f;
        return (playerTransform.position.y >= transform.position.y + OffscreenerOffset);
    }
}