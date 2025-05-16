using UnityEngine;

/// <summary>
/// Clase base abstracta para todas las habilidades del juego.
/// Define propiedades comunes y la lógica de enfriamiento.
/// </summary>
public abstract class Skill : ScriptableObject
{
    [Header("Skill Properties")]
    [SerializeField] private string skillName;      // Nombre de la habilidad
    [SerializeField] private Sprite icon;           // Icono de la habilidad
    [SerializeField] private float cooldown;        // Tiempo de enfriamiento total
    [SerializeField] private float activationCost;  // Costo de activación (vida, energía, etc.)
    private float currentCooldown; // Tiempo restante de enfriamiento
    public string SkillName => skillName; // Nombre de la habilidad
    public Sprite Icon => icon; // Icono de la habilidad
    public float Cooldown => cooldown; // Tiempo de enfriamiento total
    public float ActivationCost => activationCost; // Costo de activación

    public float CurrentCooldown
    {
        // Propiedad que representa el tiempo restante de enfriamiento
        get => currentCooldown;
        protected set => currentCooldown = Mathf.Clamp(value, 0, cooldown);
    }

    /// Método abstracto que define la lógica específica de la habilidad.
    public abstract void Execute(GameObject user);

    /// Usa la habilidad si no está en enfriamiento.
    public void Use(GameObject user)
    {
        // Verifica si la habilidad está en enfriamiento
        if (CurrentCooldown > 0)
        {
            // Si está en enfriamiento, no la usa y muestra un mensaje
            Debug.Log($"{SkillName} está en enfriamiento. Tiempo restante: {CurrentCooldown:F2} segundos.");
            return;
        }
        // Si no está en enfriamiento, ejecuta la habilidad
        Execute(user);
        CurrentCooldown = Cooldown;
    }

    // Reduce el enfriamiento de la habilidad con el tiempo.
    public void CooldownTick(float deltaTime)
    {
        if (CurrentCooldown > 0)
        {
            CurrentCooldown -= deltaTime;
            CurrentCooldown = Mathf.Clamp(CurrentCooldown, 0, Cooldown);
        }
    }

    // Indica si la habilidad está lista para usarse.
    public bool IsReady()
    {
        return CurrentCooldown <= 0;
    }
}