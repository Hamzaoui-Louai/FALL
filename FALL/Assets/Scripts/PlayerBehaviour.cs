using UnityEngine;

public enum PlayerDirection { None, Left, Right }

public class PlayerBehaviour : MonoBehaviour
{
    const float MaxBallRotationSpeed = 1f; 
    const float BallRotationAcceleration = 0.1f; // the ball takes 10 frames to reach max speed, which is 1/6 of a second at 60fps. 
    [SerializeField] const float BallMovementSpeedToVelocityRatio = 8f;

    float ballRotationSpeed = 0f;
    float ballMovementSpeed = 0f;
    float ballMovementAcceleration = 0f;
    [SerializeField] float grip = 0.1f;
    PlayerDirection direction = PlayerDirection.None;

    Rigidbody2D rb;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    public PlayerDirection GetDirection() => direction;
    public float GetBallRotationSpeed() => ballRotationSpeed;

    public void RotateRight() => direction = PlayerDirection.Right;
    public void RotateLeft() => direction = PlayerDirection.Left;
    public void Stop() => direction = PlayerDirection.None;

    void FixedUpdate()
    {

        //ball rotation speed logic 

        // Accelerates or decelerates ballRotationSpeed toward the direction's
        // target (+max / -max / 0), clamped so it never overshoots.
        if (direction == PlayerDirection.Right)
            ballRotationSpeed = Mathf.Min(ballRotationSpeed + BallRotationAcceleration, MaxBallRotationSpeed);
        else if (direction == PlayerDirection.Left)
            ballRotationSpeed = Mathf.Max(ballRotationSpeed - BallRotationAcceleration, -MaxBallRotationSpeed);
        else if (ballRotationSpeed > 0f)
            ballRotationSpeed = Mathf.Max(ballRotationSpeed - BallRotationAcceleration, 0f);
        else
            ballRotationSpeed = Mathf.Min(ballRotationSpeed + BallRotationAcceleration, 0f);

        Debug.Log($"Ball speed: {ballRotationSpeed}");

        //ball movement logic
        ballMovementAcceleration = -(ballMovementSpeed - ballRotationSpeed) * grip;
        ballMovementSpeed += ballMovementAcceleration;
        rb.linearVelocity = new Vector2(ballMovementSpeed * BallMovementSpeedToVelocityRatio, rb.linearVelocity.y);

        Debug.Log($"Movement speed: {ballMovementSpeed}, Acceleration: {ballMovementAcceleration}");
    }
}
