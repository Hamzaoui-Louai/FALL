using UnityEngine;

[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerAnimation : MonoBehaviour
{
    const float AnimationSpeedToBallSpeedRatio = 16f; // the ball has a circumference of 16 units, so the animation speed should be 16 times the ball rotation speed

    Animator animator;
    PlayerBehaviour behaviour;
    PlayerKit kit;

    void Awake()
    {
        animator = GetComponent<Animator>();
        behaviour = GetComponent<PlayerBehaviour>();
        kit = GetComponent<PlayerKit>();
    }

    void FixedUpdate()
    {
        PlayerDirection direction = behaviour.GetDirection();

        float animationSpeed = Mathf.Abs(behaviour.GetBallRotationSpeed()) * AnimationSpeedToBallSpeedRatio;
        animator.speed = animationSpeed;

        string directionSuffix = direction == PlayerDirection.Left ? "left" : "right";
        KitType currentKit = kit.GetKit();
        string stateName = currentKit == KitType.No_kit
            ? $"No_kit_{directionSuffix}"
            : $"{currentKit}_kit_{directionSuffix}";
        animator.Play(stateName);
    }
}
