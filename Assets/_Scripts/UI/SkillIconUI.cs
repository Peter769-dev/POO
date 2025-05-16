using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillIconUI : MonoBehaviour
{
    public Image fillImage; // La imagen de color (relleno)
    public Image backgroundImage; // La imagen gris de fondo
    public TextMeshProUGUI skillNameText; // Referencia al texto para el nombre de la habilidad
    [SerializeField] private Skill skill;

    public void SetSkill(Skill skill)
    {
        this.skill = skill;
        if (backgroundImage != null)
        {
            backgroundImage.sprite = skill.Icon;
            backgroundImage.color = Color.gray;
        }
        if (fillImage != null)
        {
            fillImage.sprite = skill.Icon;
            fillImage.color = Color.white; // O el color que prefieras
        }
        if (skillNameText != null)
        {
            skillNameText.text = skill.SkillName;
        }
    }

    void Update()
    {
        if (skill != null && fillImage != null)
        {
            float fillAmount = 1f - (skill.CurrentCooldown / skill.Cooldown);
            fillImage.fillAmount = fillAmount;
        }
    }
}