using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject  myDummy;
    GameObject dummyCreated;

    public void SpawnDummy()
    {
        if (dummyCreated != null)
            return;
        dummyCreated=Instantiate(myDummy);
    }


}
