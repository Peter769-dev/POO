using UnityEngine;

/// <summary>
/// Habilidad que crea un área de daño persistente.
/// </summary>
[CreateAssetMenu(fileName = "New Area Damage", menuName = "Skills/Area Damage")]
public class AreaDamage : Skill
{
    [Header("Area Damage")]
    [SerializeField] private float damage; // Daño por tick
    [SerializeField] private LayerMask targetLayer; // Capa de los objetivos que recibirán el daño
    [SerializeField] private float duration = 3f; // Duración del área de daño
    [SerializeField] private float tickInterval = 1f; // Intervalo de daño por tick
    [SerializeField] private GameObject areaPrefab; // Prefab con AreaDamageZone

    // Inicializa el área de daño.
    public override void Execute(GameObject user)
    {
        Debug.Log($"{SkillName} ha sido usada. Creando área de daño persistente.");
        Vector3 spawnPosition = user.transform.position + new Vector3(0f, -0.82f, 0f);
        GameObject area = Instantiate(areaPrefab, spawnPosition, Quaternion.identity);
        var zone = area.GetComponent<AreaDamageZone>();
        if (zone != null)
        {
            // Configura el área de daño
            var box = area.GetComponent<BoxCollider2D>();
            if (box != null) zone.Initialize(damage, tickInterval, duration, targetLayer);
        }
    }
}