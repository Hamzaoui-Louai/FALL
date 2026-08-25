using UnityEngine;

public enum PlayerDirection { None, Left, Right }

public class PlayerBehaviour : MonoBehaviour
{
    const float MaxBallRotationSpeed = 16f; //16 means the ball rotates a full rotation once every second.
    const float BallRotationAcceleration = 1f;

    float ballRotationSpeed;
    PlayerDirection direction = PlayerDirection.None;

    public PlayerDirection GetDirection() => direction;
    public float GetBallRotationSpeed() => ballRotationSpeed;

    public void RotateRight() => direction = PlayerDirection.Right;
    public void RotateLeft() => direction = PlayerDirection.Left;
    public void Stop() => direction = PlayerDirection.None;

    // Accelerates or decelerates ballRotationSpeed toward the direction's
    // target (+max / -max / 0), clamped so it never overshoots.
    void FixedUpdate()
    {
        if (direction == PlayerDirection.Right)
            ballRotationSpeed = Mathf.Min(ballRotationSpeed + BallRotationAcceleration, MaxBallRotationSpeed);
        else if (direction == PlayerDirection.Left)
            ballRotationSpeed = Mathf.Max(ballRotationSpeed - BallRotationAcceleration, -MaxBallRotationSpeed);
        else if (ballRotationSpeed > 0f)
            ballRotationSpeed = Mathf.Max(ballRotationSpeed - BallRotationAcceleration, 0f);
        else
            ballRotationSpeed = Mathf.Min(ballRotationSpeed + BallRotationAcceleration, 0f);

        Debug.Log($"Ball speed: {ballRotationSpeed}");
    }
}
