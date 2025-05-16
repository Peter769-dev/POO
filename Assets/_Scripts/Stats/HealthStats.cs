using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// Clase base abstracta para estadísticas generales.
/// Proporciona encapsulación y métodos comunes para cualquier tipo de estadística.
/// </summary>
[System.Serializable]
public abstract class Stats
{
    [SerializeField] protected int maxValue = 100;        // Valor máximo de la estadística
    protected int currentValue;// Valor actual

    // Método abstracto para recibir daño o modificar la estadística.
    public virtual void AffectStat(float amount)
    {
        // Modifica el valor actual de la estadística según la cantidad proporcionada
        currentValue = Mathf.Clamp(currentValue + Mathf.RoundToInt(amount), 0, maxValue);
    }

    public void Initialize()
    {
        currentValue = maxValue; // Inicializa el valor actual al máximo
    }
}



// Clase derivada para estadísticas de salud.
[System.Serializable]
public class HealthStats : Stats
{
    // Vida actual del personaje.
    public int CurrentHealth
    {
        get => currentValue;
    }

    // Vida máxima del personaje.
    public int MaxHealth
    {
        get => maxValue;
    }

    private void Start()
    {
        // Inicialización de valores
        maxValue = 100;
        currentValue = maxValue;
    }

    // Recibe daño (o curación si el valor es negativo) y verifica si el personaje muere.
    // <param name="amount">Cantidad de daño (o curación negativa).</param>
    public override void AffectStat(float amount)
    {
        base.AffectStat(amount);

        // Si la salud actual es menor o igual a cero, el personaje muere
        if (CurrentHealth <= 0)
        {
            // Si el personaje muere, se ejecuta la lógica de muerte
            Debug.Log("El personaje ha muerto.");
            OnDeath();
        }
    }

    // Método virtual para manejar la muerte (puede ser sobrescrito por clases hijas).
    protected virtual void OnDeath()
    {
        //Debug.Log("Manejando la muerte del personaje.");
        // Lógica adicional para la muerte
    }
}