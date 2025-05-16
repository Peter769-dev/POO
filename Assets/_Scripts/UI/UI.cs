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
    private HealthStats healthStats; // Referencia a las estadísticas de salud
    private EnergyStats energyStats; // Referencia a las estadísticas de energía

    void Start()
    {
        // Buscar automáticamente un objeto que herede de PlayableCarrier
        player = Object.FindFirstObjectByType<PlayableCarrier>();

        // Validar referencias
        if (player == null)
            Debug.LogError("No se encontró un agente en la escena que herede de PlayableCarrier.");
        else
        {
            // Obtener las estadísticas de salud y energía del jugador
            healthStats = player.HealthSystem;
            energyStats = player.EnergySystem;
        }

        if (healthText == null || energyText == null)
            Debug.LogError("No se asignaron los textos de la UI en el script UI.");
        if (healthSlider == null || energySlider == null)
            Debug.LogError("No se asignaron los sliders de la UI en el script UI.");

        UpdateUI();
    }

    void Update()
    {
        // Actualizar la UI cada frame
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (!player) return;

        if (healthStats != null)
        {
            // Actualizar el texto y el slider de vida
            healthText.text = $"Vida: {healthStats.CurrentHealth}/{healthStats.MaxHealth}";
            healthSlider.value = (float)healthStats.CurrentHealth / healthStats.MaxHealth;
        }

        if (energyStats != null)
        {
            // Actualizar el texto y el slider de energía
            energyText.text = $"Energía: {energyStats.CurrentEnergy}/{energyStats.MaxEnergy}";
            energySlider.value = (float)energyStats.CurrentEnergy / energyStats.MaxEnergy;
        }
    }
}