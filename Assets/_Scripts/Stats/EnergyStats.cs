using UnityEngine;

// Clase para manejar las estadísticas de energía
public class EnergyStats : MonoBehaviour
{
    // Propiedades protegidas para encapsulación
    protected int currentEnergy;
    protected int maxEnergy;

    // Tipo de condición de energía
    public EnergyConditionType EnergyCondition { get; set; }

    // Referencia al sistema de salud
    private HealthStats healthSystem;

    private void Start()
    {
        // Inicialización de valores
        maxEnergy = 100;
        currentEnergy = maxEnergy;
        EnergyCondition = EnergyConditionType.None; // Condición predeterminada

        // Obtener referencia al sistema de salud
        healthSystem = GetComponent<HealthStats>();
        if (healthSystem == null)
        {
            Debug.LogError("No se encontró un componente HealthStats en el objeto.");
        }
    }

    // Método para consumir energía
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

    // Método para recuperar energía
    public void RecoverEnergy(float amount)
    {
        currentEnergy += Mathf.RoundToInt(amount);
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
    }

    // Método para curar energía y vida
    public void Heal(float amount)
    {
        // Restaurar vida si el sistema de salud está disponible
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(-amount); // Curar vida usando daño negativo
            Debug.Log("Vida restaurada.");
        }
    }

    // Método para actualizar la energía según la condición
    public void UpdateEnergy()
    {
        switch (EnergyCondition)
        {
            case EnergyConditionType.Time:
                Debug.Log("Actualizando energía basada en el tiempo.");
                // Lógica para regenerar energía con el tiempo
                break;

            case EnergyConditionType.Interaction:
                Debug.Log("Actualizando energía basada en interacciones.");
                // Lógica para regenerar energía con interacciones
                break;

            case EnergyConditionType.None:
                Debug.Log("Sin condición de energía.");
                // No se realiza ninguna acción
                break;
        }
    }

    // Propiedad pública para obtener la energía actual
    public int CurrentEnergy
    {
        get => currentEnergy;
    }

    // Propiedad pública para obtener la energía máxima
    public int MaxEnergy
    {
        get => maxEnergy;
    }
}