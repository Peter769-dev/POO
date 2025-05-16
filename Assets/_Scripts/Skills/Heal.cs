using UnityEngine;

/// <summary>
/// Habilidad que cura vida al usuario.
/// </summary>
[CreateAssetMenu(fileName = "New Heal", menuName = "Skills/Heal")]
public class Heal : Skill
{
    [SerializeField] private float healAmount; // Cantidad de vida a curar

    public override void Execute(GameObject user)
    {
        HealthStats healthStats = user.GetComponent<Carrier>().HealthSystem;
        if (healthStats != null)
        {
            // Aplica la curación al sistema de salud del usuario
            healthStats.AffectStat(healAmount); // Usa daño negativo para curar
            Debug.Log($"{SkillName} ha sido usada. Curó {healAmount} de vida.");
        }
        else
        {
            // Si no se encuentra el sistema de salud, muestra un mensaje de advertencia
            Debug.LogWarning("No se encontró un sistema de salud para curar.");
        }
    }
}