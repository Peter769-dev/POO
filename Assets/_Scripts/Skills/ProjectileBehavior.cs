using UnityEngine;

/// <summary>
/// Controla el comportamiento de un proyectil: movimiento, colisión y daño.
/// </summary>
public class ProjectileBehavior : MonoBehaviour
{
    private float damage; // Daño que inflige el proyectil
    [SerializeField] private float speed = 10f; // Velocidad del proyectil
    [SerializeField] private float lifetime = 5f; // Tiempo de vida del proyectil

    private void Start()
    {
        // Destruir el proyectil después de un tiempo
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Mover el proyectil hacia la derecha (espacio 2D)
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Solo destruir el proyectil si colisiona con un objeto con la tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            HealthStats targetHealth = other.GetComponent<Carrier>().HealthSystem;

            if (targetHealth != null)
            {
                targetHealth.AffectStat(-damage);
                Debug.Log($"El proyectil infligió {damage} de daño a {other.name}.");
            }
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Configura el daño del proyectil.
    /// </summary>
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}