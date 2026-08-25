using UnityEngine;

[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerAnimation : MonoBehaviour
{
    const float AnimationSpeedToBallSpeedRatio = 1f;

    Animator animator;
    PlayerBehaviour behaviour;

    void Awake()
    {
        animator = GetComponent<Animator>();
        behaviour = GetComponent<PlayerBehaviour>();
    }

    void FixedUpdate()
    {
        PlayerDirection direction = behaviour.GetDirection();

        float animationSpeed = Mathf.Abs(behaviour.GetBallRotationSpeed()) * AnimationSpeedToBallSpeedRatio;
        animator.speed = animationSpeed;

        string directionSuffix = direction == PlayerDirection.Left ? "left" : "right";
        string stateName = $"No_kit_{directionSuffix}";
        animator.Play(stateName);
    }
}
