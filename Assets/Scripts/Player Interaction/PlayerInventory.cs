using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    public int SeedAmount = 1;

    public void PlantSeed()
    {
        SeedAmount--;
    }

    public void HarvestSeeds(int amount)
    {
        SeedAmount += amount;
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }
}
