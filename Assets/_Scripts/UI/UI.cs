using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Controla la actualización de la interfaz de usuario para mostrar la vida y energía del jugador.
/// Busca automáticamente un PlayableCarrier en la escena y actualiza los textos y sliders.
/// </summary>
public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;   // Texto para mostrar la vida
    [SerializeField] private TextMeshProUGUI energyText;   // Texto para mostrar la energía
    [SerializeField] private Slider healthSlider;          // Slider para la vida
    [SerializeField] private Slider energySlider;          // Slider para la energía

    private PlayableCarrier player; // Referencia al agente controlado

    void Start()
    {
        // Buscar automáticamente un objeto que herede de PlayableCarrier
        player = Object.FindFirstObjectByType<PlayableCarrier>();

        // Validar referencias
        if (player == null)
            Debug.LogError("No se encontró un agente en la escena que herede de PlayableCarrier.");
        if (healthText == null || energyText == null)
            Debug.LogError("No se asignaron los textos de la UI en el script UI.");
        if (healthSlider == null || energySlider == null)
            Debug.LogError("No se asignaron los sliders de la UI en el script UI.");

        // Inicializar los sliders con los valores máximos
        if (player != null)
        {
            HealthStats healthStats = player.GetComponent<HealthStats>();
            EnergyStats energyStats = player.GetComponent<EnergyStats>();

            if (healthStats != null && healthSlider != null)
            {
                healthSlider.maxValue = healthStats.MaxHealth;
                healthSlider.value = healthStats.CurrentHealth;
            }
            if (energyStats != null && energySlider != null)
            {
                energySlider.maxValue = energyStats.MaxEnergy;
                energySlider.value = energyStats.CurrentEnergy;
            }
        }
    }

    void Update()
    {
        // Actualizar la UI con las estadísticas del agente
        if (player != null)
        {
            HealthStats healthStats = player.GetComponent<HealthStats>();
            EnergyStats energyStats = player.GetComponent<EnergyStats>();

            if (healthStats != null)
            {
                healthText.text = $"Vida: {healthStats.CurrentHealth}/{healthStats.MaxHealth}";
                if (healthSlider != null)
                    healthSlider.value = healthStats.CurrentHealth;
            }
            if (energyStats != null)
            {
                energyText.text = $"Energía: {energyStats.CurrentEnergy}/{energyStats.MaxEnergy}";
                if (energySlider != null)
                    energySlider.value = energyStats.CurrentEnergy;
            }
        }
    }
}