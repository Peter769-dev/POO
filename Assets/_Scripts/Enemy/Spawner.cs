using UnityEngine;

/// <summary>
/// Permite instanciar un Dummy en la posición del spawner.
/// </summary>
public class Spawner : MonoBehaviour
{
    public GameObject myDummy; // Prefab del Dummy a instanciar
    GameObject dummyCreated;   // Referencia al Dummy creado

    /// <summary>
    /// Instancia el Dummy si no hay uno ya creado.
    /// </summary>
    public void SpawnDummy()
    {
        if (dummyCreated != null)
            return;
        dummyCreated = Instantiate(myDummy, transform.position, transform.rotation);
    }
}
