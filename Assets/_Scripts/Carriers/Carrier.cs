using UnityEngine;

// Clase base para los portadores (Carrier)
public abstract class Carrier : MonoBehaviour
{
    // Referencia al sistema de salud
    protected HealthStats healthSystem;

    // Método para inicializar el sistema de salud
    protected virtual void Start()
    {
        healthSystem = GetComponent<HealthStats>();
        if (healthSystem == null)
        {
            Debug.LogError("No se encontró un componente HealthStats en el Carrier.");
        }
    }

    // Método para recibir daño
    public virtual void ReceiveDamage(float amount)
    {
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(amount);
        }
    }

    // Método abstracto para manejar la muerte (puede ser implementado por clases derivadas)
    protected abstract void OnDeath();
}