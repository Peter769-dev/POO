using UnityEngine;

public class Agent1 : PlayableCarrier
{
    public override void UseSkill(int index)
    {
        if (index < 0 || index >= skills.Count) return;
        Skill skill = skills[index];
        HealthStats healthSystem = GetComponent<HealthStats>();

        if (!skill.IsReady())
        {
            Debug.LogWarning($"{skill.SkillName} está en enfriamiento.");
            return;
        }

        if (healthSystem != null && healthSystem.CurrentHealth > skill.ActivationCost)
        {
            healthSystem.TakeDamage(skill.ActivationCost);
            skill.Use(gameObject);
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