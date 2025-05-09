using UnityEngine;
using TMPro; // Importar el namespace de TextMeshPro
using UnityEngine.UI; // Importar el namespace de UI para usar Sliders

public class UI : MonoBehaviour
{
    // Referencias a los textos de la UI
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI energyText;

    // Referencias a los sliders de la UI
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider energySlider;

    // Referencia al agente (puede ser Agent1 o Agent2)
    private PlayableCarrier player;

    void Start()
    {
        // Buscar automáticamente un objeto que herede de PlayableCarrier
        player = FindObjectOfType<PlayableCarrier>();

        // Validar referencias
        if (player == null)
        {
            Debug.LogError("No se encontró un agente en la escena que herede de PlayableCarrier.");
        }

        if (healthText == null || energyText == null)
        {
            Debug.LogError("No se asignaron los textos de la UI en el script UI.");
        }

        if (healthSlider == null || energySlider == null)
        {
            Debug.LogError("No se asignaron los sliders de la UI en el script UI.");
        }

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
                // Actualizar texto y slider de vida
                healthText.text = $"Vida: {healthStats.CurrentHealth}/{healthStats.MaxHealth}";
                if (healthSlider != null)
                {
                    healthSlider.value = healthStats.CurrentHealth;
                }
            }

            if (energyStats != null)
            {
                // Actualizar texto y slider de energía
                energyText.text = $"Energía: {energyStats.CurrentEnergy}/{energyStats.MaxEnergy}";
                if (energySlider != null)
                {
                    energySlider.value = energyStats.CurrentEnergy;
                }
            }
        }
    }
}