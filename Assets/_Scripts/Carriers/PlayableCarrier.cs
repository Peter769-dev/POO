using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Clase base para portadores jugables. Permite usar habilidades y gestiona su enfriamiento.
/// </summary>
public class PlayableCarrier : Carrier
{
    /// <summary>
    /// Lista de habilidades asignadas desde el Inspector.
    /// </summary>
    [SerializeField]
    protected List<Skill> skills;

    private void Update()
    {
        // Activar habilidades con las teclas 1, 2 y 3
        if (Input.GetKeyDown(KeyCode.Alpha1) && skills.Count > 0)
        {
            UseSkill(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && skills.Count > 1)
        {
            UseSkill(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && skills.Count > 2)
        {
            UseSkill(2);
        }

        // Reducir el enfriamiento de todas las habilidades
        foreach (Skill skill in skills)
        {
            skill.CooldownTick(Time.deltaTime);
        }
    }

    /// <summary>
    /// Usa la habilidad en el índice dado si existe.
    /// </summary>
    public virtual void UseSkill(int index)
    {
        if (index >= 0 && index < skills.Count)
        {
            Skill skill = skills[index];
            skill.Use(gameObject); // Pasa el GameObject del usuario a la habilidad
        }
        else
        {
            Debug.LogWarning("Índice de habilidad inválido.");
        }
    }

    /// <summary>
    /// Maneja la lógica de muerte del portador jugable.
    /// </summary>
    protected override void OnDeath()
    {
        Debug.Log("El portador jugable ha muerto.");
        // Aquí puedes agregar lógica adicional, como reiniciar el nivel o mostrar un mensaje de derrota
    }
}