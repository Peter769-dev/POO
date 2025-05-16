using UnityEngine;

/// <summary>
/// Portador jugable que usa energía (mana) para activar habilidades.
/// </summary>
public class Agent2 : PlayableCarrier
{
    /// <summary>
    /// Usa la habilidad si hay suficiente energía y el enfriamiento lo permite.
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

        // Verifica si hay suficiente energía para usar la habilidad
        if (energySystem != null && energySystem.CurrentEnergy >= skill.ActivationCost)
        {
            // Resta la energía necesaria para usar la habilidad
            energySystem.AffectStat(-skill.ActivationCost);
            skill.Use(gameObject);
        }
        else
        {
            // Si no hay suficiente energía, muestra un mensaje de advertencia
            Debug.LogWarning("No hay suficiente mana para usar esta habilidad.");
        }
    }

    // Lógica de muerte específica para Agent2.
    protected override void OnDeath()
    {
        Debug.Log("El Agente 2 ha muerto.");
        // Lógica adicional específica para Agent2
    }
}