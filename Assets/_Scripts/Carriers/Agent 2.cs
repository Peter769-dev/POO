using UnityEngine;

public class Agent2 : PlayableCarrier
{
    [SerializeField]
    private float manaCost = 10f;

    public override void UseSkill(int index)
    {
        EnergyStats energySystem = GetComponent<EnergyStats>();

        if (energySystem != null && energySystem.CurrentEnergy >= manaCost)
        {
            energySystem.UseEnergy(manaCost); // Consume mana
            base.UseSkill(index); // Usa la habilidad desde PlayableCarrier
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