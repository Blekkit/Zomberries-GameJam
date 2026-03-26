using UnityEngine;

public class Field : MonoBehaviour
{
    public EFieldState FieldState = EFieldState.Empty;

    [SerializeField] private Canvas _interactionCanvas;
    //[SerializeField] private PlayerInventory _playerInventory;

    private bool _isInteractionsOpen = false;

    public void OnClick()
    {
        if (_isInteractionsOpen)
            CloseInteractions();
        else
            OpenInteractions();
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
}