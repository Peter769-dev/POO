using UnityEngine;

/// <summary>
/// Portador no jugable que puede recibir daño y morir.
/// </summary>
public class NonPlayableCarrier : Carrier
{
    // Usa la habilidad si hay suficiente vida y el enfriamiento lo permite.
    [Header("UI")]
    [SerializeField] private DummyHealth dummyHealth; // Asigna esto desde el inspector

    void Update()
    {
        // Verifica si el sistema de salud está asignado
        if (healthSystem.CurrentHealth <= 0)
        {
            OnDeath(); // Llamar al método de muerte
        }
    }

    // Maneja la muerte del portador no jugable.
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