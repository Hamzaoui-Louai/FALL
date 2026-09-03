using UnityEngine;

public enum PlayerDirection { None, Left, Right }

public class PlayerBehaviour : MonoBehaviour
{
    const float MaxBallRotationSpeed = 1f; 
    const float BallRotationAcceleration = 0.1f; // the ball takes 10 frames to reach max speed, which is 1/6 of a second at 60fps. 
    const float BallMovementSpeedToVelocityRatio = 8f;
    const float SlowFallingSpeed = 4f;

    float ballRotationSpeed = 0f;
    float ballMovementSpeed = 0f;
    float ballMovementAcceleration = 0f;
    [SerializeField] float grip = 0.1f;
    PlayerDirection direction = PlayerDirection.None;

    Rigidbody2D rb;
    PlayerKit kit;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        kit = GetComponent<PlayerKit>();
    }

    public PlayerDirection GetDirection() => direction;
    public float GetBallRotationSpeed() => ballRotationSpeed;
    public Vector2 GetPosition() => transform.position;
    public void SetPosition(Vector2 newPosition) => transform.position = newPosition;
    public void SetGravity(float newGravity)
    {
        rb.gravityScale = newGravity;
        if (newGravity == 0f)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
    }

    public void RotateRight() => direction = PlayerDirection.Right;
    public void RotateLeft() => direction = PlayerDirection.Left;
    public void Stop() => direction = PlayerDirection.None;

    void FixedUpdate()
    {

        //ball rotation speed logic 

        float maxBallRotationSpeed = kit.GetKit() == KitType.Speed ? MaxBallRotationSpeed * 2f : MaxBallRotationSpeed;
        float ballRotationAcceleration = kit.GetKit() == KitType.Speed ? BallRotationAcceleration * 2f : BallRotationAcceleration;

        // Accelerates or decelerates ballRotationSpeed toward the direction's
        // target (+max / -max / 0), clamped so it never overshoots.
        if (direction == PlayerDirection.Right)
            ballRotationSpeed = Mathf.Min(ballRotationSpeed + ballRotationAcceleration, maxBallRotationSpeed);
        else if (direction == PlayerDirection.Left)
            ballRotationSpeed = Mathf.Max(ballRotationSpeed - ballRotationAcceleration, -maxBallRotationSpeed);
        else if (ballRotationSpeed > 0f)
            ballRotationSpeed = Mathf.Max(ballRotationSpeed - ballRotationAcceleration, 0f);
        else
            ballRotationSpeed = Mathf.Min(ballRotationSpeed + ballRotationAcceleration, 0f);

        //ball movement logic
        ballMovementAcceleration = -(ballMovementSpeed - ballRotationSpeed) * grip;
        ballMovementSpeed += ballMovementAcceleration;
        rb.linearVelocity = new Vector2(ballMovementSpeed * BallMovementSpeedToVelocityRatio, rb.linearVelocity.y);

    }

    void Update()
    {
        //falling logic
        if (kit.GetKit() == KitType.Slowfalling)
        {
            float verticalVelocity = rb.linearVelocity.y;
            if (verticalVelocity < -SlowFallingSpeed)
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, -SlowFallingSpeed);
        }
    }
}
