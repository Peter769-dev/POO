using UnityEngine;

/// <summary>
/// Clase base abstracta para todas las habilidades del juego.
/// Define propiedades comunes y la lógica de enfriamiento.
/// </summary>
public abstract class Skill : ScriptableObject
{
    [SerializeField] private string skillName;      // Nombre de la habilidad
    [SerializeField] private Sprite icon;           // Icono de la habilidad
    [SerializeField] private float cooldown;        // Tiempo de enfriamiento total
    [SerializeField] private float activationCost;  // Costo de activación (vida, energía, etc.)

    private float currentCooldown;                  // Tiempo restante de enfriamiento

    /// <summary>
    /// Nombre de la habilidad.
    /// </summary>
    public string SkillName => skillName;

    /// <summary>
    /// Icono de la habilidad.
    /// </summary>
    public Sprite Icon => icon;

    /// <summary>
    /// Tiempo de enfriamiento total.
    /// </summary>
    public float Cooldown => cooldown;

    /// <summary>
    /// Costo de activación (vida, energía, etc.).
    /// </summary>
    public float ActivationCost => activationCost;

    /// <summary>
    /// Tiempo restante de enfriamiento.
    /// </summary>
    public float CurrentCooldown
    {
        get => currentCooldown;
        protected set => currentCooldown = Mathf.Clamp(value, 0, cooldown);
    }

    /// <summary>
    /// Método abstracto que define la lógica específica de la habilidad.
    /// </summary>
    public abstract void Execute(GameObject user);

    /// <summary>
    /// Usa la habilidad si no está en enfriamiento.
    /// </summary>
    public void Use(GameObject user)
    {
        if (CurrentCooldown > 0)
        {
            Debug.Log($"{SkillName} está en enfriamiento. Tiempo restante: {CurrentCooldown:F2} segundos.");
            return;
        }
        Execute(user);
        CurrentCooldown = Cooldown;
    }

    /// <summary>
    /// Reduce el enfriamiento de la habilidad con el tiempo.
    /// </summary>
    public void CooldownTick(float deltaTime)
    {
        if (CurrentCooldown > 0)
        {
            CurrentCooldown -= deltaTime;
            CurrentCooldown = Mathf.Clamp(CurrentCooldown, 0, Cooldown);
        }
    }

    /// <summary>
    /// Indica si la habilidad está lista para usarse.
    /// </summary>
    public bool IsReady()
    {
        return CurrentCooldown <= 0;
    }
}