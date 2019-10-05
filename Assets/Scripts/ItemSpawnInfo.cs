using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnInfo : MonoBehaviour
{
    public GameObject Item;
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;
    private int TheSpawnNumber;
    // Start is called before the first frame update
    void Start()
    {
        TheSpawnNumber = Random.Range(1, 4);
        print(TheSpawnNumber);
        Spawn();
        
    }


    void Spawn()
    {
        if (TheSpawnNumber == 1)
        {
            Instantiate(Item, SpawnPoint1.transform.position, Quaternion.identity);
        }
        if (TheSpawnNumber == 2)
        {
            Instantiate(Item, SpawnPoint2.transform.position, Quaternion.identity);
        }
        if (TheSpawnNumber == 3)
        {
            Instantiate(Item, SpawnPoint3.transform.position, Quaternion.identity);
        }

    }
}
