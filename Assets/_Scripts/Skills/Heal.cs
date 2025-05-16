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
        HealthStats healthStats = user.GetComponent<HealthStats>();
        if (healthStats != null)
        {
            healthStats.TakeDamage(-healAmount); // Usa daño negativo para curar
            Debug.Log($"{SkillName} ha sido usada. Curó {healAmount} de vida.");
        }
        else
        {
            Debug.LogWarning("No se encontró un sistema de salud para curar.");
        }
    }
}