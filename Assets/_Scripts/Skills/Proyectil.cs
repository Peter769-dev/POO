using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "Skills/Projectile")]
public class Proyectil : Skill
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float damage;

    public override void Execute(GameObject user)
    {
        Debug.Log($"{SkillName} ha sido usada. Lanzando proyectil.");

        // Instanciar el proyectil
        GameObject projectile = Instantiate(projectilePrefab, user.transform.position, user.transform.rotation);
        ProjectileBehavior behavior = projectile.GetComponent<ProjectileBehavior>();
        if (behavior != null)
        {
            behavior.SetDamage(damage);
        }
    }
}