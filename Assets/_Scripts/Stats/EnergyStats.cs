using UnityEngine;

/// <summary>
/// Clase para manejar las estadísticas de energía (mana) de un personaje.
/// Permite regeneración automática, por interacción o ninguna, según el tipo configurado.
/// </summary>

[System.Serializable]
public class EnergyStats : Stats
{
    [SerializeField] private EnergyConditionType energyCondition = EnergyConditionType.None;
    // Tipo de condición que determina cómo se regenera la energía.
    public EnergyConditionType EnergyCondition
    {
        get => energyCondition;
        set => energyCondition = value;
    }

    private HealthStats healthSystem; // Referencia opcional al sistema de salud

    // Variables para regeneración por tiempo
    private float timeCounter = 0f; // Contador de tiempo para la regeneración
    private const float regenInterval = 5f; // Intervalo de 5 segundos
    private const int regenAmount = 5; // Cantidad de energía a regenerar

    // Actualiza la energía según la condición configurada.
    public void UpdateEnergy()
    {
        switch (energyCondition)
        {
            case EnergyConditionType.Time:
                // Regenera energía cada 5 segundos
                timeCounter += Time.deltaTime;
                if (timeCounter >= regenInterval)
                {
                    AffectStat(regenAmount);
                    timeCounter = 0f;
                    Debug.Log("Energía regenerada por tiempo.");
                }
                break;

            case EnergyConditionType.Interaction:
                // Regenera energía al presionar la tecla "m"
                if (Input.GetKeyDown(KeyCode.M))
                {
                    AffectStat(50);
                    Debug.Log("Energía regenerada por interacción.");
                }
                break;

            case EnergyConditionType.None:
                // No realiza ninguna acción
                break;
        }
    }

    public override void AffectStat(float amount)
    {
        // Modifica el valor actual de la estadística según la cantidad proporcionada
        base.AffectStat(amount);
        
        if (currentValue <= 0)
        {
            // Si la energía actual es menor o igual a cero, se detiene la regeneración
            Debug.Log("Energía agotada.");
            UpdateEnergy();
        }
    }

    // Energía actual.
    public int CurrentEnergy => currentValue;

    // Energía máxima.
    public int MaxEnergy => maxValue;
}