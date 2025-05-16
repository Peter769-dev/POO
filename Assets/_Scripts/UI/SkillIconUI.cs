using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Controla la visualización de un icono de habilidad en la UI, mostrando el nombre y el progreso de enfriamiento.
/// </summary>
public class SkillIconUI : MonoBehaviour
{
    public Image fillImage; // Imagen de relleno (progreso de cooldown)
    public Image backgroundImage; // Imagen de fondo (gris)
    public TextMeshProUGUI skillNameText; // Texto para el nombre de la habilidad
    [SerializeField] private Skill skill; // Referencia a la habilidad asociada

    // Asigna una habilidad a este icono y actualiza los elementos visuales.
    public void SetSkill(Skill skill)
    {
        this.skill = skill;
        if (backgroundImage != null)
        {
            // Asigna el icono de la habilidad al fondo
            backgroundImage.sprite = skill.Icon;
            backgroundImage.color = Color.gray;
        }
        if (fillImage != null)
        {
            // Asigna el icono de la habilidad al relleno
            fillImage.sprite = skill.Icon;
            fillImage.color = Color.white;
        }
        if (skillNameText != null)
        {
            // Asigna el nombre de la habilidad al texto
            skillNameText.text = skill.SkillName;
        }
    }

    void Update()
    {
        // Actualiza el progreso de enfriamiento visualmente
        if (skill != null && fillImage != null)
        {
            // Calcula el porcentaje de enfriamiento y actualiza el relleno
            float fillAmount = 1f - (skill.CurrentCooldown / skill.Cooldown);
            fillImage.fillAmount = fillAmount;
        }
    }
}