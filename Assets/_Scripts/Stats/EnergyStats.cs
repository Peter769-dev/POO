using UnityEngine;

/// <summary>
/// Clase para manejar las estadísticas de energía (mana) de un personaje.
/// Permite regeneración automática, por interacción o ninguna, según el tipo configurado.
/// </summary>
public class EnergyStats : MonoBehaviour
{
    protected int currentEnergy; // Energía actual
    protected int maxEnergy;     // Energía máxima

    [SerializeField] private EnergyConditionType energyCondition = EnergyConditionType.None;
    /// <summary>
    /// Tipo de condición que determina cómo se regenera la energía.
    /// </summary>
    public EnergyConditionType EnergyCondition
    {
        get => energyCondition;
        set => energyCondition = value;
    }

    private HealthStats healthSystem; // Referencia opcional al sistema de salud

    // Variables para regeneración por tiempo
    private float timeCounter = 0f;
    private const float regenInterval = 5f; // Intervalo de 5 segundos
    private const int regenAmount = 5;      // Cantidad de energía a regenerar

    private void Start()
    {
        maxEnergy = 100;
        currentEnergy = maxEnergy;

        healthSystem = GetComponent<HealthStats>();
        if (healthSystem == null)
        {
            Debug.LogError("No se encontró un componente HealthStats en el objeto.");
        }
    }

    private void Update()
    {
        UpdateEnergy();
    }

    /// <summary>
    /// Consume energía.
    /// </summary>
    /// <param name="amount">Cantidad de energía a consumir (puede ser negativa para restaurar).</param>
    public void UseEnergy(float amount)
    {
        currentEnergy -= Mathf.RoundToInt(amount);
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);

        if (currentEnergy <= 0)
        {
            Debug.Log("Energía agotada.");
            UpdateEnergy();
        }
    }

    /// <summary>
    /// Recupera energía.
    /// </summary>
    /// <param name="amount">Cantidad de energía a recuperar.</param>
    public void RecoverEnergy(float amount)
    {
        currentEnergy += Mathf.RoundToInt(amount);
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
    }

    /// <summary>
    /// Cura vida usando el sistema de salud, si está disponible.
    /// </summary>
    /// <param name="amount">Cantidad de vida a curar.</param>
    public void Heal(float amount)
    {
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(-amount); // Curar vida usando daño negativo
            Debug.Log("Vida restaurada.");
        }
    }

    /// <summary>
    /// Actualiza la energía según la condición configurada.
    /// </summary>
    private void UpdateEnergy()
    {
        switch (energyCondition)
        {
            case EnergyConditionType.Time:
                // Regenera energía cada 5 segundos
                timeCounter += Time.deltaTime;
                if (timeCounter >= regenInterval)
                {
                    RecoverEnergy(regenAmount);
                    timeCounter = 0f;
                    Debug.Log("Energía regenerada por tiempo.");
                }
                break;

            case EnergyConditionType.Interaction:
                // Regenera energía al presionar la tecla "m"
                if (Input.GetKeyDown(KeyCode.M))
                {
                    RecoverEnergy(50);
                    Debug.Log("Energía regenerada por interacción.");
                }
                break;

            case EnergyConditionType.None:
                // No realiza ninguna acción
                break;
        }
    }

    /// <summary>
    /// Energía actual.
    /// </summary>
    public int CurrentEnergy => currentEnergy;

    /// <summary>
    /// Energía máxima.
    /// </summary>
    public int MaxEnergy => maxEnergy;
}