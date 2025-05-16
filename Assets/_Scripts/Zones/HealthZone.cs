using UnityEngine;

/// <summary>
/// HealthZone es un componente que, al detectar que un GameObject con EnergyStats entra en su zona,
/// comienza a restaurar energía periódicamente y deja de hacerlo cuando sale.
/// </summary>
public class HealthZone : MonoBehaviour
{
    // Referencia al componente EnergyStats del objeto que entra en la zona
    private PlayableCarrier playableCarrier;

    // Se llama automáticamente cuando otro collider entra en el trigger de este objeto.
    // Si el objeto que entra tiene un componente EnergyStats, comienza a restaurar energía cada segundo.
    // <param name="other">El collider que entra en la zona.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("ingreso"); // Mensaje de depuración para saber que alguien entró en la zona

        // Verifica si el objeto que entra tiene un componente EnergyStats
        if (other.gameObject.TryGetComponent(out PlayableCarrier targetPlayable))
        {
            // Inicia la llamada repetida al método EnergyRecharge cada 1 segundo, comenzando inmediatamente
            InvokeRepeating("EnergyRecharge", 0, 1);
            // Guarda la referencia al componente EnergyStats para usarlo en EnergyRecharge
            playableCarrier = targetPlayable;
        }
    }

    // Se llama automáticamente cuando otro collider sale del trigger de este objeto.
    // Si el objeto que sale es el mismo que estaba recibiendo energía, detiene la recarga.
    // <param name="other">El collider que sale de la zona.</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        // Verifica si el objeto que sale es el mismo que estaba recibiendo energía
        if (playableCarrier != null && other.gameObject == playableCarrier.gameObject)
        {
            CancelInvoke("getHealth");
            playableCarrier = null;
            print("salio"); // Mensaje de depuración para saber que alguien salió de la zona
        }
    }

    /// Método que se llama periódicamente para restaurar energía.
    /// Usa el método UseEnergy con un valor negativo para aumentar la energía del objeto.
    public void EnergyRecharge()
    {
        // Restaura 5 puntos de energía al objeto que está en la zona
        if (playableCarrier != null)
        {
            playableCarrier.EnergySystem.AffectStat(5);
        }
    }
}
