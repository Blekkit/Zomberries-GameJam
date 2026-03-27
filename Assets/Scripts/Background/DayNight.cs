using UnityEngine;

using UnityEngine;

public class DayNight : MonoBehaviour
{
    public static DayNight instance;

    [SerializeField] private int interactionsToNight = 5;
    private int currentInteractions = 0;

    private bool isNight = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        SetDay();
    }

    public void AddInteraction()
    {
        currentInteractions++;

        if (currentInteractions >= interactionsToNight && !isNight)
        {
            SetNight();
        }
    }

    private void SetDay()
    {
        isNight = false;
        Debug.Log("is daylight");
        RenderSettings.ambientLight = Color.white;
    }

    private void SetNight()
    {
        isNight = true;
        Debug.Log("is night");
        RenderSettings.ambientLight = Color.blue;
    }
}