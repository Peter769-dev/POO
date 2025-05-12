using UnityEngine;

public class Agent1 : PlayableCarrier
{
    [SerializeField]
    private float healthCost = 10f;

    public override void UseSkill(int index)
    {
        HealthStats healthSystem = GetComponent<HealthStats>();

        if (healthSystem != null && healthSystem.CurrentHealth > healthCost)
        {
            healthSystem.TakeDamage(healthCost); // Consume vida
            base.UseSkill(index); // Usa la habilidad desde PlayableCarrier
        }
        else
        {
            Debug.LogWarning("No hay suficiente vida para usar esta habilidad.");
        }
    }

    protected override void OnDeath()
    {
        Debug.Log("El Agente 1 ha muerto.");
        // Lógica adicional específica para Agent1
    }
}