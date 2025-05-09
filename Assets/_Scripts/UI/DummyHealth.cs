using UnityEngine;
using UnityEngine.UI;

public class DummyHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider; // Referencia al Slider de la UI

    public HealthStats healthStats;

    private void Start()
    {
        // Obtener el componente HealthStats
        healthStats = GetComponent<HealthStats>();

        if (healthStats == null)
        {
            Debug.LogError("No se encontró un componente HealthStats en el Dummy.");
            return;
        }

        // Inicializar el Slider con los valores de HealthStats
        if (healthSlider != null)
        {
            healthSlider.maxValue = healthStats.MaxHealth;
            healthSlider.value = healthStats.CurrentHealth;
        }
        else
        {
            Debug.LogError("No se asignó un Slider al DummyHealth.");
        }
    }

    private void Update()
    {
        // Actualizar el Slider con los valores actuales de HealthStats
        if (healthStats != null && healthSlider != null)
        {
            healthSlider.value = healthStats.CurrentHealth;
        }
    }
}