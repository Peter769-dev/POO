using UnityEngine;

public class NonPlayableCarrier : Carrier
{
    // Método para recibir daño
    public void TakeDamage(float amount)
    {
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(amount); // Reducir la vida
            Debug.Log($"NonPlayableCarrier recibió {amount} de daño. Vida restante: {healthSystem.CurrentHealth}");

            if (healthSystem.CurrentHealth <= 0)
            {
                OnDeath(); // Llamar al método de muerte
            }
        }
        else
        {
            Debug.LogError("No se encontró un sistema de salud en NonPlayableCarrier.");
        }
    }

    void Update()
    {
        if (healthSystem.CurrentHealth <= 0)
            {
                OnDeath(); // Llamar al método de muerte
            }
    }

    // Método para manejar la muerte
    protected override void OnDeath()
    {
        Debug.Log("NonPlayableCarrier ha muerto.");
        // Aquí puedes agregar lógica adicional, como destruir el objeto
        Destroy(gameObject);
    }
}