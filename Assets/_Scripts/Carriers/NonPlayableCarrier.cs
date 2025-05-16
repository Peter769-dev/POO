using UnityEngine;

/// <summary>
/// Portador no jugable que puede recibir daño y morir.
/// </summary>
public class NonPlayableCarrier : Carrier
{
    [Header("UI")]
    [SerializeField] private DummyHealth dummyHealth; // Asigna esto desde el inspector

    /// <summary>
    /// Método para recibir daño y verificar muerte.
    /// </summary>
    public void TakeDamage(float amount)
    {
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(amount); // Reducir la vida
            Debug.Log($"NonPlayableCarrier recibió {amount} de daño. Vida restante: {healthSystem.CurrentHealth}");
        }
        else
        {
            Debug.LogError("No se encontró un sistema de salud en NonPlayableCarrier.");
        }
    }

    void Update()
    {
        if (healthSystem.CurrentHealth <= 0)
        {
            OnDeath(); // Llamar al método de muerte
        }
    }

    /// <summary>
    /// Maneja la muerte del portador no jugable.
    /// </summary>
    protected override void OnDeath()
    {
        // Si hay un DummyHealth asignado, actualiza el slider a 0
        if (dummyHealth != null && dummyHealth.HealthSlider != null)
        {
            dummyHealth.HealthSlider.value = 0;
        }

        Debug.Log("NonPlayableCarrier ha muerto.");
        Destroy(gameObject);
    }
}