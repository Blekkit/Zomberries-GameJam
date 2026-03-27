using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    public int SeedAmount = 1;

    [SerializeField] private TMP_Text _seedAmountText;

    public void PlantSeed()
    {
        SeedAmount--;
        UpdateSeedAmountText();
    }

    public void HarvestSeeds(int amount)
    {
        SeedAmount += amount;
        UpdateSeedAmountText();
    }

    private void UpdateSeedAmountText()
    {
        _seedAmountText.text = $"Seeds: {SeedAmount}";
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        UpdateSeedAmountText();
    }
}
