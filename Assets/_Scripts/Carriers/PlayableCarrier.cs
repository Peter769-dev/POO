using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Clase base para portadores jugables. Permite usar habilidades y gestiona su enfriamiento.
/// </summary>
public class PlayableCarrier : Carrier
{
    [SerializeField]
    protected EnergyStats energySystem; // Referencia al sistema de energía (mana)

    // Lista de habilidades asignadas desde el Inspector.
    [SerializeField]
    protected List<Skill> skills;
    public EnergyStats EnergySystem => energySystem;

    protected override void Start()
    {
        base.Start(); // Inicializa el sistema de salud
        energySystem.Initialize();
    }

    private void Update()
    {
        // Verifica si el sistema de salud está asignado
        energySystem.UpdateEnergy();

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

    // Usa la habilidad en el índice dado si existe.
    public virtual void UseSkill(int index)
    {
        // Verifica si el índice es válido
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

    // Maneja la lógica de muerte del portador jugable.
    protected override void OnDeath()
    {
        Debug.Log("El portador jugable ha muerto.");
        // Aquí puedes agregar lógica adicional, como reiniciar el nivel o mostrar un mensaje de derrota
    }
}