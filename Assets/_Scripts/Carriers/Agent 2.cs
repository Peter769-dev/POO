using UnityEngine;

public class Agent2 : PlayableCarrier
{
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

    protected override void OnDeath()
    {
        Debug.Log("El Agente 2 ha muerto.");
        // Lógica adicional específica para Agent2
    }
}