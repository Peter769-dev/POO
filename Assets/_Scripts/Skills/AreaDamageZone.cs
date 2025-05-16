using UnityEngine;

/// <summary>
/// Controla el área de daño persistente: aplica daño periódico a los objetivos dentro del área.
/// </summary>
public class AreaDamageZone : MonoBehaviour
{
    private float damage; // Daño por tick
    private float tickInterval; // Intervalo entre ticks
    private float duration; // Duración total del área de daño
    private LayerMask targetLayer; // Capa de los objetivos a dañar
    private float timer; // Temporizador para la duración total
    private float tickTimer; // Temporizador para el intervalo de daño

    // Inicializa los parámetros del área de daño.
    public void Initialize(float damage, float tickInterval, float duration, LayerMask targetLayer)
    {
        this.damage = damage;
        this.tickInterval = tickInterval;
        this.duration = duration;
        this.targetLayer = targetLayer;
        timer = 0f;
        tickTimer = 0f;
    }

    void Update()
    {
        // Actualiza los temporizadores
        timer += Time.deltaTime;
        tickTimer += Time.deltaTime;

        // Aplica daño si el temporizador de ticks ha alcanzado el intervalo
        if (tickTimer >= tickInterval)
        {
            ApplyDamage();
            tickTimer = 0f;
        }

        // Destruye el objeto si ha pasado la duración total
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }

    // Aplica daño a todos los objetivos dentro del área.
    void ApplyDamage()
    {
        // Verifica si el collider es un BoxCollider2D
        var box = GetComponent<BoxCollider2D>();
        if (box == null) return;

        // Calcula el centro y tamaño del área de daño
        Vector2 center = (Vector2)transform.position + box.offset;
        Vector2 size = box.size * transform.lossyScale;

        // Aplica daño a todos los colliders dentro del área
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(center, size, transform.eulerAngles.z, targetLayer);
        foreach (Collider2D hitCollider in hitColliders)
        {
            // Verifica si el collider tiene un componente Carrier
            HealthStats targetHealth = hitCollider.GetComponent<Carrier>().HealthSystem;
            if (targetHealth != null)
            {
                // Aplica daño al objetivo
                targetHealth.AffectStat(-damage);
                Debug.Log($"Área de daño infligió {damage} a {hitCollider.name}.");
            }
        }
    }
}