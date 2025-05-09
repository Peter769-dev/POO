using UnityEngine;

public class Habilidades : ScriptableObject
{
    [SerializeField] string skillName;
    [SerializeField] Sprite icon;
    [SerializeField] float cooldown;
    [SerializeField] float currentCooldown;
    public void StartCoolDown()
    {

    }
    public void CoolDownTick() { }
}
