using UnityEngine;
using UnityEngine.UI;

public class Barradevida : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        // Initialize the health bar if needed
    }

    public void SetMaxHealth(int health)
    {
        if (slider != null)
        {
            slider.maxValue = health;
            slider.value = health;
        }
    }

    public void SetHealth(int health)
    {
        if (slider != null)
        {
            slider.value = health;
        }
    }
}