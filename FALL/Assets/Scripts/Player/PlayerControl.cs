using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerControl : MonoBehaviour
{
    PlayerBehaviour behaviour;
    PlayerLifecycle lifecycle;

    void Awake()
    {
        behaviour = GetComponent<PlayerBehaviour>();
        lifecycle = GetComponent<PlayerLifecycle>();
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (lifecycle.IsOffscreened() && keyboard.anyKey.wasPressedThisFrame)
        {
            lifecycle.Respawn();
            return;
        }

        if (lifecycle.IsDead()) return;

        bool right = keyboard.rightArrowKey.isPressed;
        bool left = keyboard.leftArrowKey.isPressed;

        if (right && !left)
            behaviour.RotateRight();
        else if (left && !right)
            behaviour.RotateLeft();
        else
            behaviour.Stop();
    }
}
