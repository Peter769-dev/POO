using UnityEngine;

/// <summary>
/// Clase base abstracta para estadísticas generales.
/// Proporciona encapsulación y métodos comunes para cualquier tipo de estadística.
/// </summary>
public abstract class Stats : MonoBehaviour
{
    [SerializeField] protected int maxValue = 100;        // Valor máximo de la estadística
    [SerializeField] protected int currentValue = int.MaxValue; // Valor actual

    /// <summary>
    /// Método abstracto para recibir daño o modificar la estadística.
    /// </summary>
    public abstract void TakeDamage(float amount);

    /// <summary>
    /// Limita el valor actual entre 0 y el máximo.
    /// </summary>
    protected void ClampValue()
    {
        currentValue = Mathf.Clamp(currentValue, 0, maxValue);
    }
}

/// <summary>
/// Clase derivada para estadísticas de salud.
/// </summary>
public class HealthStats : Stats
{
    /// <summary>
    /// Vida actual del personaje.
    /// </summary>
    public int CurrentHealth
    {
        get => currentValue;
        private set => currentValue = Mathf.Clamp(value, 0, maxValue);
    }

    /// <summary>
    /// Vida máxima del personaje.
    /// </summary>
    public int MaxHealth
    {
        get => maxValue;
        set => maxValue = Mathf.Max(1, value); // Asegura que maxHealth sea al menos 1
    }

    private void Start()
    {
        // Inicialización de valores
        maxValue = 100;
        currentValue = maxValue;
    }

    /// <summary>
    /// Recibe daño (o curación si el valor es negativo) y verifica si el personaje muere.
    /// </summary>
    /// <param name="amount">Cantidad de daño (o curación negativa).</param>
    public override void TakeDamage(float amount)
    {
        CurrentHealth -= Mathf.RoundToInt(amount);
        ClampValue();

        if (CurrentHealth <= 0)
        {
            Debug.Log("El personaje ha muerto.");
            OnDeath();
        }
    }

    /// <summary>
    /// Método virtual para manejar la muerte (puede ser sobrescrito por clases hijas).
    /// </summary>
    protected virtual void OnDeath()
    {
        //Debug.Log("Manejando la muerte del personaje.");
        // Lógica adicional para la muerte
    }
}