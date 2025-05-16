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
        Debug.Log($"{SkillName} ha sido usada. Lanzando proyectil.");
        GameObject projectile = Instantiate(projectilePrefab, user.transform.position, user.transform.rotation);
        ProjectileBehavior behavior = projectile.GetComponent<ProjectileBehavior>();
        if (behavior != null)
        {
            behavior.SetDamage(damage);
        }
    }
}