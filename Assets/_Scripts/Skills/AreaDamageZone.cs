using UnityEngine;

public class AreaDamageZone : MonoBehaviour
{
    private float damage;
    private float tickInterval;
    private float duration;
    private LayerMask targetLayer;
    private float timer;
    private float tickTimer;

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
        timer += Time.deltaTime;
        tickTimer += Time.deltaTime;

        if (tickTimer >= tickInterval)
        {
            ApplyDamage();
            tickTimer = 0f;
        }

        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }

    void ApplyDamage()
    {
        var box = GetComponent<BoxCollider2D>();
        if (box == null) return;

        // Calcula el centro y tamaño del área
        Vector2 center = (Vector2)transform.position + box.offset;
        Vector2 size = box.size * transform.lossyScale;

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(center, size, transform.eulerAngles.z, targetLayer);
        foreach (Collider2D hitCollider in hitColliders)
        {
            HealthStats targetHealth = hitCollider.GetComponent<HealthStats>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage);
                Debug.Log($"Área de daño infligió {damage} a {hitCollider.name}.");
            }
        }
    }
}