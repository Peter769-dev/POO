using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla la barra de vida (Slider) de un Dummy, sincronizándola con su HealthStats.
/// </summary>
public class DummyHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider; // Referencia al Slider de la UI
    [SerializeField] private Carrier carrier; // Referencia al Slider de la UI
    public Slider HealthSlider => healthSlider; // Propiedad pública de solo lectura

    private void Start()
    {
        // Buscar automáticamente un objeto que herede de Carrier
        if (carrier == null)
        {
            Debug.LogError("No se encontró un componente Carrier en el Dummy.");
            return;
        }

        UpdateBar();
    }

    private void Update()
    {
        // Actualizar el Slider cada frame
        UpdateBar();
    }

    private  void UpdateBar()
    {
        // Actualizar el Slider con los valores actuales de HealthStats
        if (healthSlider != null && carrier.HealthSystem != null)
        {
            healthSlider.value = (float)carrier.HealthSystem.CurrentHealth / carrier.HealthSystem.MaxHealth;
        }
        else
        {
            Debug.LogError("No se asignó un Slider al DummyHealth.");
        }
    }
}