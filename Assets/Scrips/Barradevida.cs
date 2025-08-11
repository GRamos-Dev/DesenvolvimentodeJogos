using UnityEngine;
using UnityEngine.UI;

public class Barradevida : MonoBehaviour
{

    public Slider slider;


    public void ColocarvidaMaxima(float vida)
    {
        slider.maxValue = vida;
        slider.value = vida;
    }
    public void AlterarVida(float vida)
    {
        slider.value = vida;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
