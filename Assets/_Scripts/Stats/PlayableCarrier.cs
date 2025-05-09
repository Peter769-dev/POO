using UnityEngine;
using System.Collections.Generic;

// Clase para un portador jugable
public class PlayableCarrier : Carrier
{
    // Lista de habilidades del jugador
    // private List<Skill> skills;

    // Referencia al sistema de energía
    protected EnergyStats energySystem;

    private void Awake()
    {
        // Inicializar la lista de habilidades
        // skills = new List<Skill>();

        // Obtener referencia al sistema de energía
        energySystem = GetComponent<EnergyStats>();
        if (energySystem == null)
        {
            Debug.LogError("No se encontró un componente EnergyStats en el portador jugable.");
        }
    }

    // Método para agregar una habilidad al portador
    /*
    public void AddSkill(Skill skill)
    {
        if (skill != null && !skills.Contains(skill))
        {
            skills.Add(skill);
            Debug.Log($"Habilidad {skill.GetName()} añadida.");
        }
    }
    */

    // Método para usar una habilidad
    /*
    public void UseSkill(int index)
    {
        if (index >= 0 && index < skills.Count)
        {
            skills[index].Use();
        }
        else
        {
            Debug.LogWarning("Índice de habilidad inválido.");
        }
    }
    */

    // Método para consumir energía
    public void ConsumeEnergy(float amount)
    {
        if (energySystem != null)
        {
            energySystem.UseEnergy(amount);
        }
        else
        {
            Debug.LogWarning("No se puede consumir energía porque no hay un sistema de energía.");
        }
    }

    // Método para recuperar energía
    public void RecoverEnergy(float amount)
    {
        if (energySystem != null)
        {
            energySystem.RecoverEnergy(amount);
        }
        else
        {
            Debug.LogWarning("No se puede recuperar energía porque no hay un sistema de energía.");
        }
    }

    // Implementación del método abstracto OnDeath
    protected override void OnDeath()
    {
        Debug.Log("El portador jugable ha muerto.");
        // Lógica adicional para manejar la muerte del jugador
    }
}