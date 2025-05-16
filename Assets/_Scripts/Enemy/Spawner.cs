using UnityEngine;

/// <summary>
/// Permite instanciar un Dummy en la posición del spawner.
/// </summary>
public class Spawner : MonoBehaviour
{
    public GameObject myDummy; // Prefab del Dummy a instanciar
    GameObject dummyCreated;   // Referencia al Dummy creado

    // Instancia el Dummy si no hay uno ya creado.
    public void SpawnDummy()
    {
        // Verifica si el Dummy ya ha sido creado
        if (dummyCreated != null)
            return;
        // Instancia el Dummy en la posición y rotación del spawner
        dummyCreated = Instantiate(myDummy, transform.position, transform.rotation);
    }
}
