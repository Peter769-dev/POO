using UnityEngine;

/// <summary>
/// DamageZone es un componente que, al detectar que un GameObject con HealthStats entra en su zona,
/// comienza a quitar vida periódicamente y deja de hacerlo cuando sale.
/// </summary>
public class DamageZone : MonoBehaviour
{
    // Referencia al componente HealthStats del objeto que entra en la zona
    private HealthStats targetHealth;

    /// <summary>
    /// Se llama automáticamente cuando otro collider entra en el trigger de este objeto.
    /// Si el objeto que entra tiene un componente HealthStats, comienza a quitar vida cada segundo.
    /// </summary>
    /// <param name="other">El collider que entra en la zona.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entró a la zona de daño"); // Mensaje de depuración

        // Verifica si el objeto que entra tiene un componente HealthStats
        if (other.gameObject.TryGetComponent<HealthStats>(out HealthStats health))
        {
            // Inicia la llamada repetida al método ApplyDamage cada 1 segundo, comenzando inmediatamente
            InvokeRepeating(nameof(ApplyDamage), 0, 1);
            // Guarda la referencia al componente HealthStats para usarlo en ApplyDamage
            targetHealth = health;
        }
    }

    /// <summary>
    /// Se llama automáticamente cuando otro collider sale del trigger de este objeto.
    /// Si el objeto que sale es el mismo que estaba recibiendo daño, detiene el daño periódico.
    /// </summary>
    /// <param name="other">El collider que sale de la zona.</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica si el objeto que sale es el mismo que estaba recibiendo daño
        if (targetHealth != null && other.gameObject == targetHealth.gameObject)
        {
            CancelInvoke(nameof(ApplyDamage));
            targetHealth = null;
            Debug.Log("Salió de la zona de daño"); // Mensaje de depuración
        }
    }

    /// <summary>
    /// Método que se llama periódicamente para quitar vida.
    /// Usa el método TakeDamage para reducir la vida del objeto.
    /// </summary>
    private void ApplyDamage()
    {
        // Quita 5 puntos de vida al objeto que está en la zona
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(5);
        }
    }
}