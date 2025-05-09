using UnityEngine;

public class NonPlayableCarrier : Carrier
{
    [SerializeField]
    private float damageAmount = 10f; // Cantidad de daño que recibirá al presionar F

    private void Update()
    {
        // Detectar si se presiona la tecla F
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(damageAmount);
        }
    }

    // Método para recibir daño
    public void TakeDamage(float amount)
    {
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(amount);
            Debug.Log($"NonPlayableCarrier recibió {amount} de daño. Vida restante: {healthSystem.CurrentHealth}");

            if (healthSystem.CurrentHealth <= 0)
            {
                OnDeath();
            }
        }
        else
        {
            Debug.LogError("No se encontró un sistema de salud en NonPlayableCarrier.");
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