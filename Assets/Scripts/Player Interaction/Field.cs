using UnityEngine;

public class Field : MonoBehaviour
{
    public EFieldState FieldState = EFieldState.Empty;

    [SerializeField] private Canvas _interactionCanvas;

    private bool _isInteractionsOpen = false;
    private bool _canInteract = true;

    public void OnClick()
    {
        if (_canInteract)
        {
            if (_isInteractionsOpen)
            {
                CloseInteractions();
                DeselectionManager.Instance.DeleteLastField();
            }
            else
            {
                OpenInteractions();
                DeselectionManager.Instance.CloseLastField();
                DeselectionManager.Instance.SaveLastField(this);

            }
        }
    }

    private void OpenInteractions()
    {
        _interactionCanvas.gameObject.SetActive(true);
        _isInteractionsOpen = true;
    }

    private void CloseInteractions()
    {
        _interactionCanvas.gameObject.SetActive(false);
        _isInteractionsOpen = false;
    }

    public void OnStartNight()
    {
        _canInteract = false;
        CloseInteractions();
    }

    public void OnStartDay()
    {
        _canInteract = true;
    }
}