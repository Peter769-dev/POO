using UnityEngine;

[CreateAssetMenu(fileName = "New Area Damage", menuName = "Skills/Area Damage")]
public class AreaDamage : Skill
{
    [SerializeField] private float damage; // Daño que inflige el área
    [SerializeField] private float radius; // Radio del área de daño
    [SerializeField] private LayerMask targetLayer; // Capa de los objetivos afectados

    public override void Execute(GameObject user)
    {
        Debug.Log($"{SkillName} ha sido usada. Creando área de daño.");

        // Crear el área de daño
        Collider[] hitColliders = Physics.OverlapSphere(user.transform.position, radius, targetLayer);
        foreach (Collider hitCollider in hitColliders)
        {
            // Buscar el componente HealthStats en los objetos afectados
            HealthStats targetHealth = hitCollider.GetComponent<HealthStats>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage); // Aplicar daño
                Debug.Log($"Infligió {damage} de daño a {hitCollider.name}.");
            }
        }
    }
}