using UnityEngine;

/// <summary>
/// Clase base abstracta para los portadores (Carrier).
/// Define la referencia al sistema de salud y métodos para recibir daño y manejar la muerte.
/// </summary>
public abstract class Carrier : MonoBehaviour
{
    /// <summary>
    /// Referencia al sistema de salud del portador.
    /// </summary>
    protected HealthStats healthSystem;

    /// <summary>
    /// Inicializa el sistema de salud al iniciar el objeto.
    /// </summary>
    protected virtual void Start()
    {
        healthSystem = GetComponent<HealthStats>();
        if (healthSystem == null)
        {
            Debug.LogError("No se encontró un componente HealthStats en el Carrier.");
        }
    }

    /// <summary>
    /// Método virtual para recibir daño y reducir la vida.
    /// </summary>
    public virtual void ReceiveDamage(float amount)
    {
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(amount);
        }
    }

    /// <summary>
    /// Método abstracto para manejar la muerte, implementado por las clases derivadas.
    /// </summary>
    protected abstract void OnDeath();
}