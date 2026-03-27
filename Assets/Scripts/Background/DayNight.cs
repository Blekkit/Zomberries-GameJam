using UnityEngine;

using UnityEngine;
using UnityEngine.Events;

public class DayNight : MonoBehaviour
{
    public UnityEvent turnDay;
    public UnityEvent turnNight;
    public static DayNight instance;

    public int DayCount { get; private set; }

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
        DayCount = 1;
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
        turnDay?.Invoke();
        RenderSettings.ambientLight = Color.white;
        DayCount++;
    }

    private void SetNight()
    {
        isNight = true;
        turnNight?.Invoke();
        RenderSettings.ambientLight = Color.blue;


    }
}