using UnityEngine;

public class MousePositionProvider : MonoBehaviour
{
    public static MousePositionProvider Instance;

    private Vector2 _mouseScreenPosition;

    public Vector2 GetMouseScreenPosition()
    {
        return _mouseScreenPosition;
    }

    public void OnMouseMoce(Vector2 mouseScreenposition)
    {
        _mouseScreenPosition = mouseScreenposition;
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
}
