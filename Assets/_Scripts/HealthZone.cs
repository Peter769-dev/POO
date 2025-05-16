using UnityEngine;

public class HealthZone : MonoBehaviour
{
    EnergyStats coffee;     //coffee referencia el componente
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("ingresó");
        if (other.gameObject.TryGetComponent<EnergyStats>(out EnergyStats temporalEnergy))
        {
        InvokeRepeating("getHealth", 0, 1);
        coffee = temporalEnergy;
        }
    }
    public void getHealth()
    {
        coffee.UseEnergy(-5);
    }
}
