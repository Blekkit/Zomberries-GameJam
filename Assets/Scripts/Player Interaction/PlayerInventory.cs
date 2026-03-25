using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int SeedAmount = 1;
    //public UnityEvent Reach0Seeds;

    public void PlantSeed()
    {
        SeedAmount--;
        //if (SeedAmount == 0)
        //{
        //    Reach0Seeds?.Invoke();
        //}
    }

    public void HarvestSeeds(int amount)
    {
        SeedAmount += amount;
    }
}
