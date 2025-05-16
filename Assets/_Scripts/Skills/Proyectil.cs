using UnityEngine;

/// <summary>
/// Habilidad que lanza un proyectil al usarla.
/// </summary>
[CreateAssetMenu(fileName = "New Projectile", menuName = "Skills/Projectile")]
public class Proyectil : Skill
{
    [SerializeField] private GameObject projectilePrefab; // Prefab del proyectil
    [SerializeField] private float damage;                // Daño del proyectil

    public override void Execute(GameObject user)
    {
        // Verifica si el prefab del proyectil está asignado
        Debug.Log($"{SkillName} ha sido usada. Lanzando proyectil.");
        GameObject projectile = Instantiate(projectilePrefab, user.transform.position, user.transform.rotation);
        ProjectileBehavior behavior = projectile.GetComponent<ProjectileBehavior>();
        if (behavior != null)
        {
            // Configura el daño del proyectil
            behavior.SetDamage(damage);
        }
    }
}