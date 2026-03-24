using UnityEngine;

public class Field : ClickableBase
{
    public EFieldState FieldState = EFieldState.Empty;

    [SerializeField] private Canvas _interactionCanvas;
    [SerializeField] private PlayerInventory _playerInventory;

    public override void OnClick()
    {
        if (FieldState != EFieldState.BigPlant)
            FieldState++;
    }

    private void OpenInteractions()
    {
        _interactionCanvas.gameObject.SetActive(true);
    }

    private void PlantSeed()
    {
        FieldState = EFieldState.Seeds;
        _playerInventory.SeedAmount--;
    }
}