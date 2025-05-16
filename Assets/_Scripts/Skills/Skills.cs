using UnityEngine;

public abstract class Skill : ScriptableObject
{
    public string SkillName;
    public Sprite Icon;
    public float Cooldown;
    public float CurrentCooldown;
    public float ActivationCost;

    public abstract void Execute(GameObject user); // Método que define la lógica de la habilidad

    public void Use(GameObject user)
    {
        if (CurrentCooldown > 0)
        {
            Debug.Log($"{SkillName} está en enfriamiento. Tiempo restante: {CurrentCooldown:F2} segundos.");
            return;
        }

        // Ejecutar la habilidad
        Execute(user);

        // Reiniciar el cooldown
        CurrentCooldown = Cooldown;
    }

    public void CooldownTick(float deltaTime)
    {
        if (CurrentCooldown > 0)
        {
            CurrentCooldown -= deltaTime;
            CurrentCooldown = Mathf.Clamp(CurrentCooldown, 0, Cooldown);
        }
    }

    public bool IsReady()
    {
        return CurrentCooldown <= 0;
    }
}