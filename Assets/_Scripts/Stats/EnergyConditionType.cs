/// <summary>
/// Enumeración para los tipos de condiciones de energía.
/// </summary>
public enum EnergyConditionType
{
    Time,          // Condición basada en el tiempo (regeneración automática)
    Interaction,   // Condición basada en interacciones (tecla)
    None           // Sin condición (no regenera)
}