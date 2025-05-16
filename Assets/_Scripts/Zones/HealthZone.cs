using UnityEngine;

/// <summary>
/// HealthZone es un componente que, al detectar que un GameObject con EnergyStats entra en su zona,
/// comienza a restaurar energía periódicamente y deja de hacerlo cuando sale.
/// </summary>
public class HealthZone : MonoBehaviour
{
    // Referencia al componente EnergyStats del objeto que entra en la zona
    private EnergyStats coffee;

    /// <summary>
    /// Se llama automáticamente cuando otro collider entra en el trigger de este objeto.
    /// Si el objeto que entra tiene un componente EnergyStats, comienza a restaurar energía cada segundo.
    /// </summary>
    /// <param name="other">El collider que entra en la zona.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("ingreso"); // Mensaje de depuración para saber que alguien entró en la zona

        // Verifica si el objeto que entra tiene un componente EnergyStats
        if (other.gameObject.TryGetComponent<EnergyStats>(out EnergyStats temporalEnergy))
        {
            // Inicia la llamada repetida al método getHealth cada 1 segundo, comenzando inmediatamente
            InvokeRepeating("getHealth", 0, 1);
            // Guarda la referencia al componente EnergyStats para usarlo en getHealth
            coffee = temporalEnergy;
        }
    }

    /// <summary>
    /// Se llama automáticamente cuando otro collider sale del trigger de este objeto.
    /// Si el objeto que sale es el mismo que estaba recibiendo energía, detiene la recarga.
    /// </summary>
    /// <param name="other">El collider que sale de la zona.</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica si el objeto que sale es el mismo que estaba recibiendo energía
        if (coffee != null && other.gameObject == coffee.gameObject)
        {
            CancelInvoke("getHealth");
            coffee = null;
            print("salio"); // Mensaje de depuración para saber que alguien salió de la zona
        }
    }

    /// <summary>
    /// Método que se llama periódicamente para restaurar energía.
    /// Usa el método UseEnergy con un valor negativo para aumentar la energía del objeto.
    /// </summary>
    public void getHealth()
    {
        // Restaura 5 puntos de energía al objeto que está en la zona
        if (coffee != null)
        {
            coffee.UseEnergy(-5);
        }
    }
}
