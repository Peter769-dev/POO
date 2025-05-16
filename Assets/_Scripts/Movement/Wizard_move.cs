using UnityEngine;

/// <summary>
/// Controla el movimiento 2D del personaje usando Rigidbody2D y entrada de usuario.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Wizard_move : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // Velocidad de movimiento
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// Lee la entrada y mueve el personaje usando Rigidbody2D.
    /// </summary>
    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(horizontal, vertical).normalized;
        rb.linearVelocity = direction * speed;
    }

    private void OnDisable()
    {
        if (rb != null)
            rb.linearVelocity = Vector2.zero;
    }
}
