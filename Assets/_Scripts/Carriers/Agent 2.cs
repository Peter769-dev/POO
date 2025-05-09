using UnityEngine;

public class Agent2 : PlayableCarrier
{
    // Costo de mana para lanzar habilidades
    [SerializeField]
    private float manaCost = 10f;

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
        if (energySystem != null) // energySystem es heredado de PlayableCarrier
        {
            if (energySystem.CurrentEnergy >= manaCost)
            {
                energySystem.UseEnergy(manaCost);
                Debug.Log("Habilidad lanzada, mana consumido.");
                // Aquí puedes agregar la lógica de la habilidad
            }
            else
            {
                Debug.LogWarning("No hay suficiente mana para lanzar la habilidad.");
            }
        }
        else
        {
            Debug.LogError("No se encontró un sistema de energía en el agente.");
        }
    }

    protected override void OnDeath()
    {
        Debug.Log("El Agente 2 ha muerto.");
        // Lógica adicional específica para Agent2
    }
}