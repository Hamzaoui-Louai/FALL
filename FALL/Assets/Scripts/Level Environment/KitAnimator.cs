using UnityEngine;

[RequireComponent(typeof(Animator))]
public class KitAnimator : MonoBehaviour
{
    [SerializeField] string animationStateName;

    Animator animator;

    void Awake() => animator = GetComponent<Animator>();

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            animator.Play(animationStateName);
    }
}