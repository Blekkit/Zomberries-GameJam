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
    [SerializeField] private BulletShooter _bulletShooter;
    [SerializeField] private string _plantAlreadyThereText = "There is a plant already.";
    [SerializeField] private string _plantAtMaxGrowthText = "Plant already at max growth.";
    [SerializeField] private string _noPlantToHarvestText = "No grown plant to harvest.";
    [SerializeField] private string _noPlantToWaterText = "No plant to water.";
    [SerializeField] private string _noSeedsText = "No Seeds left.";
    [SerializeField] private GameObject _modelSeeds;
    [SerializeField] private GameObject _modelPlant;
    [SerializeField] private GameObject _modelRipe;
    [SerializeField] private GameObject _modelStrong;


    public void PlantSeed()
    {
        _field.FieldState = EFieldState.Seeds;
        ChangeModelToState(EFieldState.Seeds);
        PlayerInventory.Instance.PlantSeed();

        ChangeButtonEnabled(_plantSeedsButton, false, _plantAlreadyThereText);
        ChangeButtonEnabled(_wateringButton, true, WATER_BUTTON_TEXT);

        _bulletShooter.SetCanFire(false);
    }

    public void WaterPlant()
    {
        _field.FieldState++;
        ChangeModelToState(_field.FieldState);
        DayNight.instance.AddInteraction();

        if (_field.FieldState == EFieldState.StrongPlant)
            ChangeButtonEnabled(_wateringButton, false, _plantAtMaxGrowthText);

        if (_field.FieldState > EFieldState.Seeds)
        {
            ChangeButtonEnabled(_harvestButton, true, HARVEST_BUTTON_TEXT);

            _bulletShooter.SetCanFire(true);
        }
    }

    public void HarvestSeeds()
    {
        PlayerInventory.Instance.HarvestSeeds((int)_field.FieldState);
        _field.FieldState = EFieldState.Empty;
        ChangeModelToState(EFieldState.Empty);

        ChangeButtonEnabled(_harvestButton, false, _noPlantToHarvestText);
        ChangeButtonEnabled(_wateringButton, false, _noPlantToWaterText);
        ChangeButtonEnabled(_plantSeedsButton, true, PLANT_BUTTON_TEXT);

        _bulletShooter.SetCanFire(false);
    }

    private void ChangeButtonEnabled(Button button, bool enabledValue, string newButtonText)
    {
        TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
        button.enabled = enabledValue;
        buttonText.text = newButtonText;
    }

    private void ChangeModelToState(EFieldState fieldState)
    {
        if (fieldState != EFieldState.Seeds)
            _modelSeeds.SetActive(false);
        else
            _modelSeeds.SetActive(true);

        if (fieldState != EFieldState.SmallPlant)
            _modelPlant.SetActive(false);
        else
            _modelPlant.SetActive(true);

        if (fieldState != EFieldState.RipePlant)
            _modelRipe.SetActive(false);
        else
            _modelRipe.SetActive(true);

        if (fieldState != EFieldState.StrongPlant)
            _modelStrong.SetActive(false);
        else
            _modelStrong.SetActive(true);
    }

    private void OnEnable()
    {
        if (_field.FieldState == EFieldState.Empty)
            ChangeButtonEnabled(_wateringButton, false, _noPlantToWaterText);
        else if (_field.FieldState == EFieldState.StrongPlant)
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

    private void Update()
    {
        if (PlayerInventory.Instance.SeedAmount <= 0)
            ChangeButtonEnabled(_plantSeedsButton, false, _noSeedsText);
        else if (_field.FieldState == EFieldState.Empty)
            ChangeButtonEnabled(_plantSeedsButton, true, PLANT_BUTTON_TEXT);
    }
}
