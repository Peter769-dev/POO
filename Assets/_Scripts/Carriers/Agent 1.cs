using UnityEngine;

public class Agent1 : PlayableCarrier
{
    // Costo de vida para lanzar habilidades
    [SerializeField]
    private float healthCost = 10f;

    private void Update()
    {
        // Ejemplo: Lanzar habilidad al presionar la tecla "F"
        if (Input.GetKeyDown(KeyCode.F))
        {
            CastSkill();
        }
    }

    // Método para lanzar una habilidad
    private void CastSkill()
    {
        HealthStats healthSystem = GetComponent<HealthStats>();

        if (healthSystem != null)
        {
            if (healthSystem.CurrentHealth > healthCost)
            {
                healthSystem.TakeDamage(healthCost); // Consume vida
                Debug.Log("Habilidad lanzada, vida consumida.");
                // Aquí puedes agregar la lógica de la habilidad
            }
            else
            {
                Debug.LogWarning("No hay suficiente vida para lanzar la habilidad.");
            }
        }
        else
        {
            Debug.LogError("No se encontró un sistema de salud en el agente.");
        }
    }
}