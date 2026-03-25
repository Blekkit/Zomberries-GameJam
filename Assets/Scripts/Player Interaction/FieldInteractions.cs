using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class FieldInteractions : MonoBehaviour
{
    private const string PLANT_BUTTON_TEXT = "Plant Seeds", WATER_BUTTON_TEXT = "Water Plant", HARVEST_BUTTON_TEXT = "Havest Plant";

    [SerializeField] private Button _plantSeedsButton;
    [SerializeField] private Button _wateringButton;
    [SerializeField] private Button _harvestButton;
    [SerializeField] private Field _field;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private string _plantAlreadyThereText = "There is a plant already.";
    [SerializeField] private string _plantAtMaxGrowthText = "Plant already at max growth.";
    [SerializeField] private string _noPlantToHarvestText = "No grown plant to harvest.";
    [SerializeField] private string _noPlantToWaterText = "No plant to water.";

    public void PlantSeed()
    {
        _field.FieldState = EFieldState.Seeds;
        _playerInventory.SeedAmount--;

        ChangeButtonEnabled(_plantSeedsButton, false, _plantAlreadyThereText);
        ChangeButtonEnabled(_wateringButton, true, WATER_BUTTON_TEXT);

        //_plantSeedsButton.enabled = false;
        //_wateringButton.enabled = true;
    }

    public void WaterPlant()
    {
        _field.FieldState++;
        if (_field.FieldState == EFieldState.BigPlant)
            ChangeButtonEnabled(_wateringButton, false, _plantAtMaxGrowthText);
            //_wateringButton.enabled = false;

        if (_field.FieldState > EFieldState.Seeds)
            ChangeButtonEnabled(_harvestButton, true, HARVEST_BUTTON_TEXT);
            //_harvestButton.enabled = true;
    }

    public void HarvestSeeds()
    {
        _playerInventory.SeedAmount += (int)_field.FieldState;
        _field.FieldState = EFieldState.Empty;

        ChangeButtonEnabled(_harvestButton, false, _noPlantToHarvestText);
        ChangeButtonEnabled(_wateringButton, false, _noPlantToWaterText);
        ChangeButtonEnabled(_plantSeedsButton, true, PLANT_BUTTON_TEXT);
        //_plantSeedsButton.enabled = true;
        //_wateringButton.enabled = false;
        //_harvestButton.enabled = false;
    }

    private void ChangeButtonEnabled(Button button, bool enabledValue, string newButtonText)
    {
        TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
        button.enabled = enabledValue;
        buttonText.text = newButtonText;
    }

    private void OnEnable()
    {
        if (_field.FieldState == EFieldState.Empty)
            ChangeButtonEnabled(_wateringButton, false, _noPlantToWaterText);
        else if (_field.FieldState == EFieldState.BigPlant)
            ChangeButtonEnabled(_wateringButton, false, _plantAtMaxGrowthText);
        else
            ChangeButtonEnabled(_wateringButton, true, WATER_BUTTON_TEXT);

        if (_field.FieldState < EFieldState.SmallPlant)
            ChangeButtonEnabled(_harvestButton, false, _noPlantToHarvestText);
        else
            ChangeButtonEnabled(_harvestButton, true, HARVEST_BUTTON_TEXT);

        if (_field.FieldState != EFieldState.Empty)
            ChangeButtonEnabled(_plantSeedsButton, false, _plantAlreadyThereText);
        else
            ChangeButtonEnabled(_plantSeedsButton, true, PLANT_BUTTON_TEXT);
    }
}
