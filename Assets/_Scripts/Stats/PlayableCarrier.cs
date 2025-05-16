using UnityEngine;
using System.Collections.Generic;

public class PlayableCarrier : Carrier
{
    [SerializeField]
    protected List<Skill> skills; // Lista de habilidades asignadas desde el Inspector

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

    protected override void OnDeath()
    {
        Debug.Log("El portador jugable ha muerto.");
        // Aquí puedes agregar lógica adicional, como reiniciar el nivel o mostrar un mensaje de derrota
    }
}