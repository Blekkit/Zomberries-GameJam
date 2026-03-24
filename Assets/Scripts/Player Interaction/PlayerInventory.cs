using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int SeedAmount = 1;

    public void PlantSeed()
    {
        SeedAmount--;
    }

    public void HarvestSeeds(int amount)
    {
        SeedAmount += amount;
    }
}
