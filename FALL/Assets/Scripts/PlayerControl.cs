using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerControl : MonoBehaviour
{
    PlayerBehaviour behaviour;

    void Awake() => behaviour = GetComponent<PlayerBehaviour>();

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

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
