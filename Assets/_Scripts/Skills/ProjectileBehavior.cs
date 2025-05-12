using UnityEngine;

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
        // Mover el proyectil hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar colisión con un objeto que tenga HealthStats
        HealthStats targetHealth = other.GetComponent<HealthStats>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
            Debug.Log($"El proyectil infligió {damage} de daño a {other.name}.");
        }

        // Destruir el proyectil al impactar
        Destroy(gameObject);
    }

    // Método para configurar el daño del proyectil
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}