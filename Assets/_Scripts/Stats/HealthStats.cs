using UnityEngine;

// Clase base abstracta para estadísticas generales
public abstract class Stats : MonoBehaviour
{
    // Propiedades protegidas para encapsulación
    [SerializeField] protected int maxValue = 100;
    [SerializeField] protected int currentValue = int.MaxValue;

    // Métodos abstractos para polimorfismo
    public abstract void TakeDamage(float amount);

    // Método común para clamping
    protected void ClampValue()
    {
        currentValue = Mathf.Clamp(currentValue, 0, maxValue);
    }
}

// Clase derivada para estadísticas de salud
public class HealthStats : Stats
{
    // Propiedades públicas con encapsulación
    public int CurrentHealth
    {
        get => currentValue;
        private set => currentValue = Mathf.Clamp(value, 0, maxValue);
    }

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

    // Implementación del método abstracto para recibir daño
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

    // Método virtual para manejar la muerte (puede ser sobrescrito)
    protected virtual void OnDeath()
    {
        Debug.Log("Manejando la muerte del personaje.");
        // Lógica adicional para la muerte
    }
}