using UnityEngine;

/// <summary>
/// Habilidad que crea un área de daño persistente.
/// </summary>
[CreateAssetMenu(fileName = "New Area Damage", menuName = "Skills/Area Damage")]
public class AreaDamage : Skill
{
    [SerializeField] private float damage;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float duration = 3f;
    [SerializeField] private float tickInterval = 1f;
    [SerializeField] private GameObject areaPrefab; // Prefab con AreaDamageZone

    public override void Execute(GameObject user)
    {
        Debug.Log($"{SkillName} ha sido usada. Creando área de daño persistente.");
        Vector3 spawnPosition = user.transform.position + new Vector3(0f, -0.82f, 0f);
        GameObject area = Instantiate(areaPrefab, spawnPosition, Quaternion.identity);
        var zone = area.GetComponent<AreaDamageZone>();
        if (zone != null)
        {
            var box = area.GetComponent<BoxCollider2D>();
            if (box != null)
                box.size = new Vector2(radius, radius);

            zone.Initialize(damage, tickInterval, duration, targetLayer);
        }
    }
}