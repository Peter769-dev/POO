using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla la barra de vida (Slider) de un Dummy, sincronizándola con su HealthStats.
/// </summary>
public class DummyHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider; // Referencia al Slider de la UI
    public Slider HealthSlider => healthSlider;   // Propiedad pública de solo lectura

    public HealthStats healthStats; // Referencia al componente HealthStats

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