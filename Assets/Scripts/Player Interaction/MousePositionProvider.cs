using UnityEngine;
using UnityEngine.InputSystem;

public class MousePositionProvider : MonoBehaviour
{
    public static MousePositionProvider Instance;

    private Vector2 _mouseScreenPosition;

    public Vector2 GetMouseScreenPosition()
    {
        return _mouseScreenPosition;
    }

    public void OnMouseMove(InputAction.CallbackContext context)
    {
        _mouseScreenPosition = context.ReadValue<Vector2>();
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
}
