using UnityEngine;
using TMPro; // Importar el namespace de TextMeshPro

public class UI : MonoBehaviour
{
    // Referencias a los textos de la UI
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI energyText;

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
            }

            if (energyStats != null)
            {
                energyText.text = $"Energía: {energyStats.CurrentEnergy}/{energyStats.MaxEnergy}";
            }
        }
    }
}