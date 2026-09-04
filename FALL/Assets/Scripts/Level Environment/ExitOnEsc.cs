using UnityEngine;
using UnityEngine.InputSystem;

public class ExitOnEsc : MonoBehaviour
{
    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard.escapeKey.wasPressedThisFrame)
            Application.Quit();
    }
}