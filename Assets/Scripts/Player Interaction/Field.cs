using UnityEngine;

public class Field : MonoBehaviour
{
    public EFieldState FieldState = EFieldState.Empty;

    [SerializeField] private Canvas _interactionCanvas;

    private bool _isInteractionsOpen = false;

    public void OnClick()
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
        CloseInteractions();
    }

    private void Awake()
    {
        
    }
}