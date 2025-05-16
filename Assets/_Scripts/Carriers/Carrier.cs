using UnityEngine;

/// <summary>
/// Clase base abstracta para los portadores (Carrier).
/// Define la referencia al sistema de salud y métodos para recibir daño y manejar la muerte.
/// </summary>
public abstract class Carrier : MonoBehaviour
{
    // Referencia al sistema de salud del portador.
    [SerializeField] protected HealthStats healthSystem;
    public HealthStats HealthSystem => healthSystem;

    // Inicializa el sistema de salud al iniciar el objeto.
    protected virtual void Start()
    {
        healthSystem.Initialize();
    }

    // Método virtual para recibir daño y reducir la vida.
    public virtual void ReceiveDamage(float amount)
    {
        if (healthSystem != null)
        {
            healthSystem.AffectStat(amount);
        }
    }

    // Método abstracto para manejar la muerte, implementado por las clases derivadas.
    protected abstract void OnDeath();
}