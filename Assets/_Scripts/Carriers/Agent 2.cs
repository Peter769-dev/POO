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
        if (index < 0 || index >= skills.Count) return;
        Skill skill = skills[index];
        EnergyStats energySystem = GetComponent<EnergyStats>();

        if (!skill.IsReady())
        {
            Debug.LogWarning($"{skill.SkillName} está en enfriamiento.");
            return;
        }

        if (energySystem != null && energySystem.CurrentEnergy >= skill.ActivationCost)
        {
            energySystem.UseEnergy(skill.ActivationCost);
            skill.Use(gameObject);
        }
        else
        {
            Debug.LogWarning("No hay suficiente mana para usar esta habilidad.");
        }
    }

    /// <summary>
    /// Lógica de muerte específica para Agent2.
    /// </summary>
    protected override void OnDeath()
    {
        Debug.Log("El Agente 2 ha muerto.");
        // Lógica adicional específica para Agent2
    }
}