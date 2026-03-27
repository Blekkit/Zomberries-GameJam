using UnityEngine;

public class DeselectionManager : MonoBehaviour
{
    public static DeselectionManager Instance;

    private Field _lastInteractedField;

    public void SaveLastField(Field field)
    {
        _lastInteractedField = field;
    }

    public void DeleteLastField()
    {
        _lastInteractedField = null;
    }

    public void CloseLastField()
    {
        if (_lastInteractedField != null)
            _lastInteractedField.OnClick();
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

    }
}
