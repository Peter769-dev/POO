using UnityEngine;

/// <summary>
/// Portador jugable que usa vida para activar habilidades.
/// </summary>
public class Agent1 : PlayableCarrier
{
    /// <summary>
    /// Usa la habilidad si hay suficiente vida y el enfriamiento lo permite.
    /// </summary>
    public override void UseSkill(int index)
    {
        // Verifica si el índice es válido
        if (index < 0 || index >= skills.Count) return;
        Skill skill = skills[index];
        // Verifica si la habilidad está lista para usarse
        if (!skill.IsReady())
        {   
            // Si no está lista, muestra un mensaje de advertencia
            Debug.LogWarning($"{skill.SkillName} está en enfriamiento.");
            return;
        }

        // Verifica si hay suficiente vida para usar la habilidad
        if (healthSystem != null && healthSystem.CurrentHealth > skill.ActivationCost)
        {
            // Resta la vida necesaria para usar la habilidad
            healthSystem.AffectStat(-skill.ActivationCost);
            skill.Use(gameObject);
        }
        else
        {
            // Si no hay suficiente vida, muestra un mensaje de advertencia
            Debug.LogWarning("No hay suficiente vida para usar esta habilidad.");
        }
    }

    // Lógica adicional al morir.
    protected override void OnDeath()
    {
        Debug.Log("El Agente 1 ha muerto.");
        // Lógica adicional específica para Agent1
    }
}