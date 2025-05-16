using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject myDummy;
    GameObject dummyCreated;

    public void SpawnDummy()
    {
        if (dummyCreated != null)
            return;
        // Instancia el dummy en la posición y rotación del spawner
        dummyCreated = Instantiate(myDummy, transform.position, transform.rotation);
    }
}
